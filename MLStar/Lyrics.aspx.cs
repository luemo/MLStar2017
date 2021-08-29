using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using MLStar.App_Code;

namespace MLStar
{
    public partial class Lyrics : System.Web.UI.Page
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
        string pPicPath = "PIC/";
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //pstrDir = (Server.UrlDecode(Request.QueryString["id"]) + "").ToString();
                pstrFile = (Server.UrlDecode(Request.QueryString["id"]) + "").ToString();

                pFun.GetSrvPath("/Data/Lyrics/");
                //pFun.GetDirsSrvPath();
                pFun.GetFilesSrvPath();
                //pFun.GetDirRequest(pstrDir);
                pFun.GetFileRequest(ref pstrFile);

                if (pFun.pstrFile == "")
                {
                    //所有填詞的目錄
                    DirList();
                    Panel_FileList.Visible = true;
                    Panel_File.Visible = false;

                    Panel_FileNext.Visible = false;
                }
                else if (pFun.pstrFile != "")
                {
                    //單一填詞網頁
                    Lyrics_iframe();
                    Panel_FileList.Visible = false;
                    Panel_File.Visible = true;

                    Panel_FileNext.Visible = true;
                }
                hidFileName.Value = pFun.pFilePath;
            }
            catch (Exception ex)
            {
                pMsg = ex.ToString();
                pSys.WriteErrorLog(ex.ToString(), pSys.GetRawUrl(Context));
            }
            //hidMsg.Value = pMsg;
        }

        #region 填詞列表
        protected void DirList()
        {
            int mI = 1;
            foreach (string item in pFun.pFilesName)
            {
                string strTitle = item;

                pTr = new TableRow();
                pTc = new TableCell();
                pTc.ID = "tc_" + mI;
                pTc.Text = "<a href='Lyrics.aspx?id=" + String.Format("{0:0000}", mI) + "' target='_self' class='content_title'>" + strTitle + "</a>";
                pTc.HorizontalAlign = HorizontalAlign.Left;
                pTr.Cells.Add(pTc);
                tabFileList.Rows.Add(pTr);
                mI++;
            }
        }
        #endregion

        #region 填詞
        protected void Lyrics_iframe()
        {
            string mPicPath = "";
            Fun mFun = new Fun();
            mFun.GetSrvPath(pFun.pPath);
            //mFun.GetDirsSrvPath();
            mFun.GetFilesSrvPath();
            //mFun.GetDirRequest(pstrDir);
            mFun.GetFileRequest(ref pstrFile);

            litLyrics.Text = mFun.GetFileString(mFun.pFileSrvPath, out pTitle);
            labTitle.Text = "<a href='Lyrics.aspx?id=" + mFun.pstrFile + "' target='_self' class='titletxt'>" + pTitle + "</a>";
            mPicPath = pFun.pSrvPath + pPicPath + mFun.pFileNameWithout + ".jpg";
            if (!File.Exists(mPicPath))
            {
                ImgLyrics.Visible = false;
            }
            else
            {
                mPicPath = pFun.pPath + pPicPath + mFun.pFileNameWithout + ".jpg";
                ImgLyrics.AlternateText = pTitle;
                ImgLyrics.Visible = true;
                ImgLyrics.ImageUrl = mPicPath;
            }

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
                labNext.Text = xFun.GetNextFile("Lyrics.aspx?id=" + xFun.GetNextFileSID(), xFun.GetNextFileName());
            }
            if (xFun.pintFile == 1)
            {
                labLast.Text = "第一篇";
            }
            else
            {
                labLast.Text = xFun.GetLastFile("Lyrics.aspx?id=" + xFun.GetLastFileSID(), xFun.GetLastFileName());
            }
        }
        #endregion
    }
}