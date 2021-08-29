using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;

namespace MLStar.App_Code
{
    public class Sys
    {
        #region 公用變數
        Fun pFun = new Fun();
        DateTime pDate;
        Encoding pEncode = System.Text.Encoding.GetEncoding("UNICODE");
        string pFilePath = "~/DataSys/";

        //public string pCnt;
        //public int pintDir, pintFile;
        //bool parsed;
        #endregion

        #region 建構式
        public Sys()
        {
            pDate = pFun.GetDateTimeToTWDateTime(DateTime.Now);
        }
        #endregion
        #region [SetVisitorCount]取遊客人數
        public void SetVisitorCount()
        {
            string mYYYYMMDD = String.Format("{0:0000}", pDate.Year) + String.Format("{0:00}", pDate.Month) + String.Format("{0:00}", pDate.Date);
            string mDate = "";
            if (HttpContext.Current.Session["LastVisitor"] != null)
            {
                mDate = HttpContext.Current.Session["LastVisitor"].ToString();
            }
            if (mDate != mYYYYMMDD)
            {
                HttpContext.Current.Session["VisitorCount"] = null;
            }
            if(HttpContext.Current.Session["VisitorCount"] == null)
            {
                mYYYYMMDD = pDate.ToString();
                string mFilePath = pFilePath + "Visitor_" + String.Format("{0:0000}", pDate.Year) + String.Format("{0:00}", pDate.Month) + ".log";
                string mClientIP = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
                string mStr;
                SetApplication_VisitorCount();
                SetSession_VisitorCount();
                mStr = pDate.ToString() + "-->[" + mClientIP + "]" + HttpContext.Current.Application["VisitorCount"] + "/" + HttpContext.Current.Session["VisitorCount"];
                WriteTXT(mFilePath, mStr);
            }
        }
        public void SetApplication_VisitorCount()
        {
            if (HttpContext.Current.Application["VisitorCount"] == null)
            {
                HttpContext.Current.Application.Lock();
                HttpContext.Current.Application["VisitorCount"] = 1;
                HttpContext.Current.Application.UnLock();
            }
            else
            {
                HttpContext.Current.Application.Lock();
                HttpContext.Current.Application["VisitorCount"] = Convert.ToInt32(HttpContext.Current.Application["VisitorCount"]) + 1;
                HttpContext.Current.Application.UnLock();
            }
        }
        public void SetSession_VisitorCount()
        {
            if (HttpContext.Current.Session["VisitorCount"] == null)
            {
                HttpContext.Current.Session["VisitorCount"] = 1;
                HttpContext.Current.Session["LastVisitor"] = String.Format("{0:0000}", pDate.Year) + String.Format("{0:00}", pDate.Month) + String.Format("{0:00}", pDate.Date);
            }
            else
            {
                HttpContext.Current.Session["VisitorCount"] = Convert.ToInt32(HttpContext.Current.Session["VisitorCount"]) + 1;
            }
        }
        #endregion

        #region [Setlog]記錄錯誤
        public void WriteErrorLog(string xErr_Msg, string xRawUrl)
        {
            string mYYYYMMDD = pDate.ToString();
            string mFilePath = pFilePath + "ex_" + String.Format("{0:0000}", pDate.Year) + String.Format("{0:00}", pDate.Month) + ".log";
            string mClientIP = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
            string mStr = mYYYYMMDD + "-->[" + xRawUrl + "]-->[" + mClientIP + "]\r\n===>" + xErr_Msg;
            WriteTXT(mFilePath, mStr);
        }
        public string GetRawUrl(HttpContext xContext)
        {
            return xContext.Request.RawUrl;
        }
        #endregion

        #region [WriteTXT]記錄讀寫
        public void WriteTXT(string xFilePath, string xStr)
        {
            using (StreamWriter sw = new StreamWriter(HttpContext.Current.Server.MapPath(xFilePath), true, pEncode))
            {
                sw.WriteLine(xStr);
            }
        }
        public void ReadTXT(string xFilePath, string xStr)
        {
            using (StreamWriter sw = new StreamWriter(HttpContext.Current.Server.MapPath(xFilePath), true, pEncode))
            {
                sw.WriteLine(xStr);
            }
        }
        #endregion

    }
}