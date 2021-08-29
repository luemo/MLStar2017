using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLStar.App_Code;


namespace MLStar
{
    public partial class Photo : System.Web.UI.Page
    {
        #region 共用變數
        Sys pSys = new Sys();
        Fun pFun = new Fun();
        TableRow pTr;
        TableCell pTc;
        string pstrDir = "";
        string pstrFile = "";
        string pMsg = "";
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                pstrDir = (Server.UrlDecode(Request.QueryString["album"]) + "").ToString();
                pstrFile = (Server.UrlDecode(Request.QueryString["id"]) + "").ToString();

                pFun.GetSrvPath("/Data/Photo/");
                pFun.GetDirsSrvPath();
                //pFun.GetFilesSrvPath();
                pFun.GetDirRequest(ref pstrDir);
                //pFun.GetFileRequest(pstrFile);

                if (pstrDir == "" && pstrFile == "")
                {
                    //所有相簿目錄
                    DirList();
                    Panel_DirList.Visible = true;
                    Panel_FileList.Visible = false;
                    Panel_File.Visible = false;

                    Panel_FileNext.Visible = false;
                    Panel_DirNext.Visible = false;
                    tabDirList.GridLines = (GridLines)3;
                }
                else if (pstrDir != "" && pstrFile == "")
                {
                    //單一相簿目錄
                    PICList();
                    Panel_DirList.Visible = false;
                    Panel_FileList.Visible = true;
                    Panel_File.Visible = false;

                    Panel_FileNext.Visible = false;
                    Panel_DirNext.Visible = true;
                    Panel_DirNext.CssClass = "div_NextFile";
                    tabFileList.GridLines = (GridLines)3;
                }
                else if (pstrDir != "" && pstrFile != "")
                {
                    //單一相片
                    PIC();
                    Panel_DirList.Visible = false;
                    Panel_FileList.Visible = false;
                    Panel_File.Visible = true;

                    Panel_FileNext.Visible = true;
                    Panel_DirNext.Visible = true;
                    Panel_FileNext.CssClass = "div_NextFile";
                    //tabFile.GridLines = (GridLines)3;
                }
            }
            catch (Exception ex)
            {
                pMsg = ex.ToString();
                pSys.WriteErrorLog(ex.ToString(), pSys.GetRawUrl(Context));
            }
            //hidMsg.Value = pMsg;
        }

        #region 相簿列表
        protected void DirList()
        {
            int mI = 1;
            int mJ = 1;
            int mNum = 0;
            int mCol = 4;   //一行有幾張相片

            foreach (string item in pFun.pDirsPath)
            {
                string strAblum = pFun.GetDateOut(pFun.pDirsName[mNum]);

                if (mI % mCol == 1)
                {
                    pTr = new TableRow();
                    mJ = 1;
                }

                pTc = new TableCell();
                pTc.ID = "tabtc_" + mI + mJ;
                pTc.Text = "<a href='Photo.aspx?album=" + String.Format("{0:0000}", mI) + "' target='_self' class='content_title_photo'> ";
                pTc.Text += "<img src='" + item + "/album.jpg' alt='" + strAblum + "' style='width: 95%'><br />";
                pTc.Text += strAblum + "</a><br />";

                pTc.HorizontalAlign = HorizontalAlign.Center;
                pTr.Cells.Add(pTc);

                if (mI % mCol == 0 || mI == pFun.pDirsName.Length)
                {
                    tabDirList.Rows.Add(pTr);
                }
                mI++;
                mJ++;
                mNum++;

                //只有名字的列表
                //pTr = new TableRow();
                //pTc = new TableCell();
                //pTc.ID = "tc_" + mI;
                //pTc.Text = "<a href='Photo.aspx?album=" + String.Format("{0:0000}", mI) + "' target='_self'>" + strAblum + "</a>";
                //pTc.HorizontalAlign = HorizontalAlign.Left;
                //pTr.Cells.Add(pTc);
                //tabDirList.Rows.Add(pTr);
                //mI++;
            }
        }
        #endregion

        #region 單個相簿
        protected void PICList()
        {
            Fun mFun = new Fun();
            mFun.GetSrvPath(pFun.pDirPath);
            //mFun.GetDirsSrvPath();
            mFun.GetFilesSrvPath();
            //mFun.GetDirRequest(pstrDir);
            //mFun.GetFileRequest(pstrFile);

            int mI = 1;
            int mJ = 1;
            int mNum = 0;
            int mCol = 4;            //一行有幾張相片
            string mPicTitle = "";   //照片的名字

            labFileListTitle.Text = pFun.GetDateOut(pFun.pDirName);

            foreach (string item in mFun.pFilesPath)
            {
                mPicTitle = pFun.GetNumberOut(mFun.pFilesName[mNum]);

                if (mI == mFun.pFilesName.Length)
                {
                    //當跑到最後一張的時候，為了避免相簿首頁被放出來，所以用continue跳過這個回合，並且將最後一行的照片加進去
                    if (mI % mCol != 0 || mI == mFun.pFilesName.Length)
                    {
                        //for (int i = 0; i <= mCol - (mI % mCol); i++)
                        //{
                        //    pTc = new TableCell();
                        //    pTr.Cells.Add(pTc);
                        //}
                        tabFileList.Rows.Add(pTr);
                    }
                    continue;
                }
                if (mI % mCol == 1)
                {
                    pTr = new TableRow();
                    mJ = 1;
                }

                pTc = new TableCell();
                pTc.ID = "tabtc_" + mI + mJ;

                pTc.Text = "<a href='Photo.aspx?album=" + pstrDir + "&id=" + String.Format("{0:0000}", mI) + "' target='_self' class='content_title_photo'> ";
                pTc.Text += "<img src='" + item + "' alt='" + mPicTitle + "' style='width: 95%'><br />";
                if (mPicTitle != "")
                {
                    pTc.Text += mPicTitle;
                }
                pTc.Text += "</a>";

                pTc.HorizontalAlign = HorizontalAlign.Center;
                pTr.Cells.Add(pTc);

                if (mI % mCol == 0 || mI == mFun.pFilesName.Length)
                {
                    tabFileList.Rows.Add(pTr);
                }
                mI++;
                mJ++;
                mNum++;
            }

            //上下頁欄位
            SetPanel_Dir(pFun);
        }
        #endregion

        #region 單張相片
        protected void PIC()
        {
            Fun mFun = new Fun();
            mFun.GetSrvPath(pFun.pDirPath);
            //mFun.GetDirsSrvPath();
            mFun.GetFilesSrvPath();
            //mFun.GetDirRequest(pstrDir);
            mFun.GetFileRequest(ref pstrFile);

            string mPicTitle = pFun.GetNumberOut(mFun.pFileNameWithout);
            if (mPicTitle == "")
            {
                mPicTitle = "無題";
            }

            pTr = new TableRow();
            pTc = new TableCell();
            pTc.ID = "tc_photo";

            pTc.Text = "";
            if (mFun.pintFile == mFun.pFilesName.Length - 1)
            {
                pTc.Text = "<a href='Photo.aspx?album=" + pstrDir + "&id=" + pstrFile + "' target='_self' class='content_title_photo' onclick='LastPic()'> ";
            }
            else
            {
                pTc.Text = "<a href='Photo.aspx?album=" + pstrDir + "&id=" + mFun.GetNextFileSID() + "' target='_self' class='content_title_photo'> ";
            }
            pTc.Text += "<img src='" + mFun.pFilePath + "' alt='" + mPicTitle + "' style='width: 95%;'><br />";
            pTc.Text += "</a>";

            pTc.HorizontalAlign = HorizontalAlign.Center;
            pTr.Cells.Add(pTc);
            tabFile.Rows.Add(pTr);

            labTitle.Text = mPicTitle;

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
                labNextDir.Text = "最後一本";
            }
            else
            {
                labNextDir.Text = xFun.GetNextDir("Photo.aspx?album=" + xFun.GetNextDirSID(), xFun.GetDateOut(xFun.GetNextDirName()));
            }
            if (xFun.pintDir == 1)
            {
                labLastDir.Text = "第一本";
            }
            else
            {
                labLastDir.Text = xFun.GetLastDir("Photo.aspx?album=" + xFun.GetLastDirSID(), xFun.GetDateOut(xFun.GetLastDirName()));
            }
        }
        protected void SetPanel_File(Fun xFun)
        {
            if (xFun.pintFile == xFun.pFilesName.Length - 1)
            {
                labNext.Text = "最後一張";
            }
            else
            {
                labNext.Text = xFun.GetNextFile("Photo.aspx?album=" + pstrDir + "&id=" + xFun.GetNextFileSID(), "下一張"); //.Replace("id=" + String.Format("{0:0000}", xFun.pFilesName.Length), "id=" + pstrFile);
            }
            if (xFun.pintFile == 1)
            {
                labLast.Text = "第一張";
            }
            else
            {
                labLast.Text = xFun.GetLastFile("Photo.aspx?album=" + pstrDir + "&id=" + xFun.GetLastFileSID(), "上一張");
            }
            labDir.Text = "<a href='Photo.aspx?album=" + String.Format("{0:0000}", pFun.pintDir) + "' target='_self' class='content_NextFiletxt'>" + xFun.GetDateOut(pFun.pDirName) + "</a>";
        }
        #endregion
    }
}