using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLStar.App_Code;

namespace MLStar
{
    public partial class Writings : System.Web.UI.Page
    {
        #region 共用變數
        Sys pSys = new Sys();
        Fun pFun = new Fun();
        TableRow pTr;
        TableCell pTc;
        //string pstrDir = "";
        string pstrFile = "";
        string pMsg = "";

        //一般變數
        string pTitle = "";
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //pstrDir = (Server.UrlDecode(Request.QueryString["id"]) + "").ToString();
                pstrFile = (Server.UrlDecode(Request.QueryString["id"]) + "").ToString();

                pFun.GetSrvPath("/Data/Writing/");
                //pFun.GetDirsSrvPath();
                pFun.GetFilesSrvPath();
                //pFun.GetDirRequest(pstrDir);
                pFun.GetFileRequest(ref pstrFile);

                if (pFun.pstrFile == "")
                {
                    //所有雜記的目錄
                    DirList();
                    Panel_FileList.Visible = true;
                    Panel_File.Visible = false;

                    Panel_FileNext.Visible = false;
                }
                else if (pFun.pstrFile != "")
                {
                    //單一雜記網頁
                    Writing_iframe();
                    Panel_FileList.Visible = false;
                    Panel_File.Visible = true;

                    Panel_FileNext.Visible = true;
                }
                hidFileName.Value = pFun.pstrFile;
            }
            catch (Exception ex)
            {
                pMsg = ex.ToString();
                pSys.WriteErrorLog(ex.ToString(), pSys.GetRawUrl(Context));
            }
            //hidMsg.Value = pMsg;
        }


        #region 雜記列表
        protected void DirList()
        {
            int mI = 1;
            SetTr(mI);
            //foreach (string item in pFun.pFilesSrvPath)
            for (mI = pFun.pFilesSrvPath.Length; mI > 1; mI--)
            {
                SetTr(mI);
            }
        }
        protected void SetTr(int xI)
        {
            string mFilesSrvPath = pFun.pFilesSrvPath[xI - 1];
            //修改一下，變成一格一格的，裡面放著標題和前面兩段，最後面可按繼續閱讀，按標題也可以進去
            string strTitle = pFun.GetDateOut(pFun.pFilesName[xI - 1]);
            string strTOP = "";
            if (xI == 1)
            {
                strTOP = "<br/>置頂貼文";
            }

            pTr = new TableRow();
            pTc = new TableCell();
            pTc.ID = "tc_" + xI;
            pTc.Text = "<table style='margin:auto;width:100%'> <tr> <td></td> <td></td> <td></td> </tr> <tr> <td></td> <td>"
                     + "<div class='title'><a href='Writings.aspx?id=" + String.Format("{0:0000}", xI) + "' target='_self' class='titletxt'>&nbsp;" + strTitle + "</a></div>"
                     + "</td> <td></td> </tr>"
                     + "<tr> <td></td> <td>"
                     + "<div class='content_time'>" + GetTime(mFilesSrvPath) + strTOP + "</div><br />";
            //pTc.Text += GetTime(item) + "< br />";
            pTc.Text += pFun.GetFileString(pFun.pFilesSrvPath[xI - 1], out pTitle, 2);
            pTc.Text += "<br /><br />　　<a href='Writings.aspx?id=" + String.Format("{0:0000}", xI) + "' target='_self' class='content_continue'>(繼續閱讀)</a><br /><br />";
            pTc.Text += "</td> <td></td> </tr> </table>";
            pTc.HorizontalAlign = HorizontalAlign.Left;
            pTr.Cells.Add(pTc);
            pTc.CssClass = "mainframe";
            tabFileList.Rows.Add(pTr);

            pTr = new TableRow();
            pTc = new TableCell();
            pTr.Height = 10;
            pTr.Cells.Add(pTc);
            tabFileList.Rows.Add(pTr);
        }
        #endregion

        #region 雜記
        protected void Writing_iframe()
        {
            //直接用table來呈現
            Fun mFun = new Fun();
            mFun.GetSrvPath(pFun.pPath);
            //mFun.GetDirsSrvPath();
            mFun.GetFilesSrvPath();
            //mFun.GetDirRequest(pstrDir);
            mFun.GetFileRequest(ref pstrFile);

            string strTOP = "";
            if (mFun.pintFile == 1)
            {
                strTOP = "<br/>置頂貼文";
            }

            pTr = new TableRow();
            pTc = new TableCell();
            pTc.ID = "tc_writings";
            pTc.Text = "<br />" + mFun.GetFileString(mFun.pFileSrvPath, out pTitle);
            labTitle.Text = "<a href='Writings.aspx?id=" + mFun.pstrFile + "' target='_self' class='titletxt'>&nbsp;" + pTitle + "</a>";
            labTime.Text = GetTime(mFun.pFileSrvPath) + strTOP;

            pTc.HorizontalAlign = HorizontalAlign.Left;
            pTr.Cells.Add(pTc);
            tabFile.Rows.Add(pTr);

            //上下頁欄位
            SetPanel_File(mFun);
        }
        #endregion

        #region 檔案、資料夾連結
        protected void SetPanel_File(Fun xFun)
        {
            if (xFun.pintFile == xFun.pFilesName.Length)
            {
                labNext.Text = "最後一篇";
            }
            else
            {
                labNext.Text = xFun.GetNextFile("Writings.aspx?id=" + xFun.GetNextFileSID(), xFun.GetDateOut(xFun.GetNextFileName()));
            }
            if (xFun.pintFile == 1)
            {
                labLast.Text = "第一篇";
            }
            else
            {
                labLast.Text = xFun.GetLastFile("Writings.aspx?id=" + xFun.GetLastFileSID(), xFun.GetDateOut(xFun.GetLastFileName()));
            }
        }
        #endregion

        #region 取檔案時間
        protected string GetTime(string xPath)
        {
            string mStr = "時間：" + pFun.GetCreatTime(xPath);
            if (pFun.GetTransactionTime(xPath) != "")
            {
                mStr += "<br />修改時間：" + pFun.GetTransactionTime(xPath);
            }
            return mStr;
        }
        #endregion
    }
}