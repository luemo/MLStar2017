using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLStar.App_Code;

namespace MLStar
{
    public partial class Novel : System.Web.UI.Page
    {
        #region 共用變數
        //公用變數
        Sys pSys = new Sys();
        Fun pFun = new Fun();
        TableRow pTr;
        TableCell pTc;
        string pstrDir = "";
        string pstrFile = "";
        string pMsg = "";

        //一般變數
        string pTitle = "";
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                pstrDir = (Server.UrlDecode(Request.QueryString["story"]) + "").ToString();
                pstrFile = (Server.UrlDecode(Request.QueryString["id"]) + "").ToString();

                pFun.GetSrvPath("/Data/Novel/");
                pFun.GetDirsSrvPath();
                //pFun.GetFilesSrvPath();
                pFun.GetDirRequest(ref pstrDir);
                //pFun.GetFileRequest(pstrFile);

                if (pstrDir == "" && pstrFile == "")
                {
                    //所有小說目錄
                    DirList();
                    Panel_DirList.Visible = true;
                    Panel_FileList.Visible = false;
                    Panel_File.Visible = false;

                    Panel_FileNext.Visible = false;
                    Panel_DirNext.Visible = false;
                }
                else if (pstrDir != "" && pstrFile == "")
                {
                    //單一小說目錄
                    NovelList();
                    Panel_DirList.Visible = false;
                    Panel_FileList.Visible = true;
                    Panel_File.Visible = false;

                    Panel_FileNext.Visible = false;
                    Panel_DirNext.Visible = true;
                    Panel_DirNext.CssClass = "div_NextFile";
                }
                else if (pstrDir != "" && pstrFile != "")
                {
                    //單一小說
                    NovelTxt();
                    Panel_DirList.Visible = false;
                    Panel_FileList.Visible = false;
                    Panel_File.Visible = true;

                    Panel_FileNext.Visible = true;
                    Panel_DirNext.Visible = true;
                    Panel_FileNext.CssClass = "div_NextFile";
                }
            }
            catch (Exception ex)
            {
                pMsg = ex.ToString();
                pSys.WriteErrorLog(ex.ToString(), pSys.GetRawUrl(Context));
            }
            //hidMsg.Value = pMsg;
            
        }

        #region 小說列表
        protected void DirList()
        {
            int mI = 1;
            foreach (string item in pFun.pDirsName)
            {
                pTr = new TableRow();
                pTc = new TableCell();
                pTc.ID = "tc_" + mI;
                pTc.Text = "<a href='Novel.aspx?story=" + String.Format("{0:0000}", mI) + "' target='_self' class='content_title'>" + pFun.GetNumberOut(item) + "</a>";
                pTc.HorizontalAlign = HorizontalAlign.Left;
                pTr.Cells.Add(pTc);
                tabDirList.Rows.Add(pTr);
                mI++;
            }
        }
        #endregion


        #region 單部小說
        protected void NovelList()
        {
            Fun mFun = new Fun();
            mFun.GetSrvPath(pFun.pDirPath);
            //mFun.GetDirsSrvPath();
            mFun.GetFilesSrvPath();
            //mFun.GetDirRequest(pstrDir);
            //mFun.GetFileRequest(pstrFile);

            int mI = 1;
            int mNum = 0;

            labFileListTitle.Text = pFun.GetNumberOut(pFun.pDirName);

            foreach (string item in mFun.pFilesName)
            {
                pTr = new TableRow();
                pTc = new TableCell();
                pTc.ID = "tabtc_" + mI;
                pTc.Text = "<a href='Novel.aspx?story=" + pstrDir + "&id=" + String.Format("{0:0000}", mI) + "' target='_self' class='content_title'>" + mFun.GetDateOut(item) + "</a>";

                pTc.HorizontalAlign = HorizontalAlign.Left;
                pTr.Cells.Add(pTc);
                tabFileList.Rows.Add(pTr);
                
                mI++;
                mNum++;
            }

            //上下頁欄位
            SetPanel_Dir(pFun);
        }
        #endregion


        #region 單篇小說
        protected void NovelTxt()
        {
            Fun mFun = new Fun();
            mFun.GetSrvPath(pFun.pDirPath);
            //mFun.GetDirsSrvPath();
            mFun.GetFilesSrvPath();
            //mFun.GetDirRequest(pstrDir);
            mFun.GetFileRequest(ref pstrFile);

            litNovel.Text = mFun.GetFileString(mFun.pFileSrvPath, out pTitle);
            labTitle.Text = pTitle;

            //上下頁欄位
            SetPanel_File(mFun);
            SetPanel_Dir(pFun);
        }
        #endregion

        #region 檔案、資料夾連結
        protected void SetPanel_Dir(Fun xFun)
        {
            if (xFun.pintDir == xFun.pDirsName.Length)
            {
                labNextDir.Text = "最後一部";
            }
            else
            {
                labNextDir.Text = xFun.GetNextDir("Novel.aspx?story=" + xFun.GetNextDirSID(), xFun.GetNumberOut(xFun.GetNextDirName()));
            }
            if (xFun.pintDir == 1)
            {
                labLastDir.Text = "第一部";
            }
            else
            {
                labLastDir.Text = xFun.GetLastDir("Novel.aspx?story=" + xFun.GetLastDirSID(), xFun.GetNumberOut(xFun.GetLastDirName()));
            }
        }
        protected void SetPanel_File(Fun xFun)
        {
            if (xFun.pintFile == xFun.pFilesName.Length)
            {
                labNext.Text = "最後一篇";
            }
            else
            {
                labNext.Text = xFun.GetNextFile("Novel.aspx?story=" + pstrDir + "&id=" + xFun.GetNextFileSID(), xFun.GetDateOut(xFun.GetNextFileName()));
            }
            if (xFun.pintFile == 1)
            {
                labLast.Text = "第一篇";
            }
            else
            {
                labLast.Text = xFun.GetLastFile("Novel.aspx?story=" + pstrDir + "&id=" + xFun.GetLastFileSID(), xFun.GetDateOut(xFun.GetLastFileName()));
            }
            labDir.Text = "<a href='Novel.aspx?story=" + String.Format("{0:0000}", pFun.pintDir) + "' target='_self' class='content_NextFiletxt'>" + pFun.GetNumberOut(pFun.pDirName) + "</a>";
        }
        #endregion
    }
}