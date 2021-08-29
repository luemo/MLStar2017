using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLStar.App_Code;

namespace MLStar
{
    public partial class Game : System.Web.UI.Page
    {
        #region 共用變數
        Sys pSys = new Sys();
        Fun pFun = new Fun();
        TableRow pTr;
        TableCell pTc;
        //string pstrDir = "";
        string pstrFile = "";
        string pMsg = "";
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //pstrDir = (Server.UrlDecode(Request.QueryString["id"]) + "").ToString();
                pstrFile = (Server.UrlDecode(Request.QueryString["id"]) + "").ToString();

                pFun.GetSrvPath("/Data/Game/");
                //pFun.GetDirsSrvPath();
                pFun.GetFilesSrvPath();
                //pFun.GetDirRequest(pstrDir);
                pFun.GetFileRequest(ref pstrFile);

                if (pFun.pstrFile == "")
                {
                    //所有遊戲介紹的目錄
                    DirList();
                    Panel_FileList.Visible = true;
                    Panel_File.Visible = false;

                    Panel_FileNext.Visible = false;
                    hidFileName.Value = "";
                }
                else if (pFun.pstrFile != "")
                {
                    //單一遊戲介紹網頁
                    Game_iframe();
                    Panel_FileList.Visible = false;
                    Panel_File.Visible = true;

                    Panel_FileNext.Visible = true;
                    hidFileName.Value = pFun.pFilePath;
                }
                
            }
            catch (Exception ex)
            {
                pMsg = ex.ToString();
                pSys.WriteErrorLog(ex.ToString(), pSys.GetRawUrl(Context));
            }
            //hidMsg.Value = pMsg;
        }

        #region 遊戲介紹列表
        protected void DirList()
        {
            int mI = 1;
            foreach (string item in pFun.pFilesName)
            {
                string strTitle = pFun.GetNumberOut(item);

                pTr = new TableRow();
                pTc = new TableCell();
                pTc.ID = "tc_" + mI;
                pTc.Text = "<a href='Game.aspx?id=" + String.Format("{0:0000}", mI) + "' target='_self' class='content_title'>" + strTitle + "</a>";
                pTc.HorizontalAlign = HorizontalAlign.Left;
                pTr.Cells.Add(pTc);
                tabFileList.Rows.Add(pTr);
                mI++;
            }
        }
        #endregion

        #region 遊戲介紹
        protected void Game_iframe()
        {
            Fun mFun = new Fun();
            mFun.GetSrvPath(pFun.pPath);
            //mFun.GetDirsSrvPath();
            mFun.GetFilesSrvPath();
            //mFun.GetDirRequest(pstrDir);
            mFun.GetFileRequest(ref pstrFile);

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
                labNext.Text = xFun.GetNextFile("Game.aspx?id=" + xFun.GetNextFileSID(), xFun.GetNumberOut(xFun.GetNextFileName()));
            }
            if (xFun.pintFile == 1)
            {
                labLast.Text = "第一篇";
            }
            else
            {
                labLast.Text = xFun.GetLastFile("Game.aspx?id=" + xFun.GetLastFileSID(), xFun.GetNumberOut(xFun.GetLastFileName()));
            }
        }
        #endregion
    }
}