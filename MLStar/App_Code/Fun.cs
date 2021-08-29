using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;

namespace MLStar.App_Code
{
    public class Fun
    {
        #region 公用變數
        public string pPath;                                    //上層相對路徑資料夾
        public string pSrvPath;                                 //上層絕對路徑資料夾
        public string[] pDirsPath, pFilesPath;                  //資料夾相對路徑陣列，檔案相對路徑陣列
        public string[] pDirsSrvPath, pFilesSrvPath;            //資料夾絕對路徑陣列，檔案絕對路徑陣列
        public string pDirPath, pFilePath;                      //資料夾相對路徑，檔案相對路徑
        public string pDirSrvPath, pFileSrvPath;                //資料夾絕對路徑，檔案絕對路徑
        public string[] pDirsName, pFilesName;                  //資料夾名稱陣列，檔案(不含附檔名)名稱陣列
        public string pDirName, pFileName, pFileNameWithout;    //資料夾名稱，檔案名稱，檔案名稱(不含附檔名)
        public string pstrDir, pstrFile;                        //資料夾數字，檔案數字
        public int pintDir, pintFile;                           //資料夾數字，檔案數字
        bool parsed;
        #endregion

        #region [GetSrvPath]取上層路徑名稱(相對路徑、絕對路徑)
        public void GetSrvPath(string xDirPath)
        {
            pPath = xDirPath;
            pSrvPath = HttpContext.Current.Server.MapPath(xDirPath);    //取絕對路徑名稱
        }
        #endregion

        #region [GetDirsSrvPath]取資料夾相對路徑、絕對路徑陣列
        public void GetDirsSrvPath()
        {
            pDirsSrvPath = Directory.GetDirectories(pSrvPath);          //取資料夾名稱陣列
            pDirsPath = Directory.GetDirectories(pSrvPath);
            pDirsName = Directory.GetDirectories(pSrvPath);
            for (int i = 0; i < pDirsPath.Length; i++)
            {
                pDirsPath[i] = pDirsPath[i].Replace(pSrvPath, pPath);
                pDirsName[i] = pDirsName[i].Replace(pSrvPath, "");
            }
        }
        #endregion

        #region [GetFilesSrvPath]取檔案相對路徑、絕對路徑陣列
        public void GetFilesSrvPath()
        {
            pFilesSrvPath = Directory.GetFiles(pSrvPath);          //取檔案名稱陣列
            pFilesPath = Directory.GetFiles(pSrvPath);
            pFilesName = Directory.GetFiles(pSrvPath);
            for (int i = 0; i < pFilesPath.Length; i++)
            {
                pFilesPath[i] = pFilesPath[i].Replace(pSrvPath, pPath);
                pFilesName[i] = Path.GetFileNameWithoutExtension(pFilesSrvPath[i]);
            }
        }
        #endregion

        #region [GetDirRequest]取選取(xDir)資料夾的名稱與排序
        public void GetDirRequest(ref string xDir)
        {
            string[] strPath;
            parsed = Int32.TryParse(xDir, out pintDir);
            if (!parsed)
            {
                pintDir = 1;
                pstrDir = "";
            }
            else
            {
                if (pintDir > pDirsSrvPath.Length || pintDir <= 0)
                {
                    pintDir = 1;
                    pstrDir = "0001";
                }
                else
                {
                    pstrDir = xDir;
                }
            }
            pDirSrvPath = pDirsSrvPath[pintDir - 1];
            pDirPath = pDirsPath[pintDir - 1];
            strPath = pDirSrvPath.Split('\\');
            pDirName = strPath[strPath.Length - 1];
            xDir = pstrDir;
        }
        #endregion

        #region [GetFileRequest]取選取(xFile)檔案的名稱與排序
        public void GetFileRequest(ref string xFile)
        {
            string[] strPath;
            parsed = Int32.TryParse(xFile, out pintFile);
            if (!parsed)
            {
                    pintFile = 1;
                    pstrFile = "";
            }
            else
            {
                if (pintFile > pFilesSrvPath.Length || pintFile <= 0)
                {
                    pintFile = 1;
                    pstrFile = "0001";
                }
                else
                {
                    pstrFile = xFile;
                }
                
            }
            pFileSrvPath = pFilesSrvPath[pintFile - 1];
            pFilePath = pFilesPath[pintFile - 1];
            strPath = pFileSrvPath.Split('\\');
            pFileName = strPath[strPath.Length - 1];
            pFileNameWithout = Path.GetFileNameWithoutExtension(pFilePath);    //取檔案名稱(包含目錄，不含副檔名)
            xFile = pstrFile;
        }
        #endregion

        #region [GetFileString]回傳檔案中的字串，xTitle為標題，return mStr為內容
        public string GetFileString(string xFilePath, out string xTitle)
        {
            string mStr = "";
            string mStr_tmp = "";
            xTitle = "";
            Encoding encode = System.Text.Encoding.GetEncoding("UNICODE");
            using (StreamReader sr = new StreamReader(xFilePath, encode))
            {
                xTitle = sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    mStr_tmp = sr.ReadLine();
                    if (mStr_tmp != "")
                    {
                        mStr += "　　" + mStr_tmp + "<br />";
                    }
                    else
                    {
                        mStr += mStr_tmp + "<br />";
                    }
                }
            }
            return mStr;
        }
        #endregion

        #region [GetFileString]回傳檔案中的字串，xTitle為標題，return mStr為內容
        public string GetFileString(string xFilePath, out string xTitle,int xRow)
        {
            string mStr = "";
            string mStr_tmp = "";
            int mRow = 0;
            xTitle = "";
            Encoding encode = System.Text.Encoding.GetEncoding("UNICODE");
            using (StreamReader sr = new StreamReader(xFilePath, encode))
            {
                if (!sr.EndOfStream)
                {
                    xTitle = sr.ReadLine();
                }
                while (!sr.EndOfStream)
                {
                    if (mRow < xRow)
                    {
                        mStr_tmp = sr.ReadLine();
                        if (mStr_tmp != "")
                        {
                            mStr += "　　" + mStr_tmp + "<br />";
                        }
                        else
                        {
                            mStr += mStr_tmp + "<br />";
                        }
                    }
                    else
                    {
                        mStr += "<br />　　...<br />";
                        break;
                    }
                    mRow++;
                }
            }
            return mStr;
        }
        #endregion

        #region [GetNextFileID、GetNextFileSID]回傳下一個檔案的ID(數字、字串、名字)
        public int GetNextFileID()
        {
            //最後一篇的連結為自身
            int mintNext = 0;
            if (pintFile == pFilesName.Length)
            { mintNext = pFilesName.Length; }
            else
            { mintNext = pintFile + 1; }
            return mintNext;
        }
        public string GetNextFileSID()
        {
            //最後一篇的連結為自身
            string mStr = String.Format("{0:0000}", GetNextFileID());
            return mStr;
        }
        public string GetNextFileName()
        {
            //第一篇的連結為自身
            return pFilesName[GetNextFileID() - 1];
        }
        #endregion

        #region [GetLastFileID、GetLastFileSID]回傳上一個檔案的ID(數字、字串、名字)
        public int GetLastFileID()
        {
            //第一篇的連結為自身
            int mintList = 0;
            if (pintFile == 1)
            { mintList = 1; }
            else
            { mintList = pintFile - 1; }
            return mintList;
        }
        public string GetLastFileSID()
        {
            //第一篇的連結為自身
            string mStr = String.Format("{0:0000}", GetLastFileID());
            return mStr;
        }
        public string GetLastFileName()
        {
            //第一篇的連結為自身
            return pFilesName[GetLastFileID() - 1];
        }
        #endregion

        #region [GetNextFile]回傳下一個檔案的連結，xLink為傳入的網址，xTitle為連結文字，return mStr為連結
        public string GetNextFile(string xLink, string xTitle)
        {
            //最後一篇的連結為自身
            string mStr = "";
            int mintNext = 0;
            if (pintFile == pFilesName.Length)
            { mintNext = pFilesName.Length; }
            else
            { mintNext = pintFile + 1; }
            xLink = xLink.Replace("@id_#", String.Format("{0:0000}", mintNext));
            //mStr = "<a href='" + xLink + "' target='_self' style='text-decoration:none;'>" + pFilesName[mintNext - 1] + "</a>";
            mStr = "<a href='" + xLink + "' target='_self' class='content_NextFiletxt'>" + xTitle + "</a>";
            return mStr;
        }
        #endregion

        #region [GetLastFile]回傳上一個檔案的連結，xLink為傳入的網址，xTitle為連結文字，return mStr為連結
        public string GetLastFile(string xLink, string xTitle)
        {
            //第一篇的連結為自身
            string mStr = "";
            int mintList = 0;
            if (pintFile == 1)
            { mintList = 1; }
            else
            { mintList = pintFile - 1; }
            xLink = xLink.Replace("@id_#", String.Format("{0:0000}", mintList));
            //mStr = "<a href='" + xLink + "' target='_self' style='text-decoration:none;'>" + pFilesName[mintList - 1] + "</a>";
            mStr = "<a href='" + xLink + "' target='_self' class='content_NextFiletxt'>" + xTitle  + "</a>";
            return mStr;
        }
        #endregion

        #region [GetNextDirID、GetNextDirSID]回傳下一個檔案的ID(數字、字串、名字)
        public int GetNextDirID()
        {
            //最後一篇的連結為自身
            int mintNext = 0;
            if (pintDir == pDirsName.Length)
            { mintNext = pDirsName.Length; }
            else
            { mintNext = pintDir + 1; }
            return mintNext;
        }
        public string GetNextDirSID()
        {
            //最後一篇的連結為自身
            string mStr = String.Format("{0:0000}", GetNextDirID());
            return mStr;
        }
        public string GetNextDirName()
        {
            //第一篇的連結為自身
            return pDirsName[GetNextDirID() - 1];
        }
        #endregion

        #region [GetLastDirID、GetLastDirSID]回傳上一個檔案的ID(數字、字串、名字)
        public int GetLastDirID()
        {
            //第一篇的連結為自身
            int mintList = 0;
            if (pintDir == 1)
            { mintList = 1; }
            else
            { mintList = pintDir - 1; }
            return mintList;
        }
        public string GetLastDirSID()
        {
            //第一篇的連結為自身
            string mStr = String.Format("{0:0000}", GetLastDirID());
            return mStr;
        }
        public string GetLastDirName()
        {
            //第一篇的連結為自身
            return pDirsName[GetLastDirID() - 1];
        }
        #endregion

        #region [GetNextDir]回傳下一個資料夾的連結，xLink為傳入的網址，xTitle為顯示名稱，return mStr為連結
        public string GetNextDir(string xLink, string xTitle)
        {
            //最後一篇的連結為自身
            string mStr = "";
            int mintNext = 0;
            if (pintDir == pDirsName.Length)
            { mintNext = pDirsName.Length; }
            else
            { mintNext = pintDir + 1; }
            xLink = xLink.Replace("@id_#", String.Format("{0:0000}", mintNext));
            mStr = "<a href='" + xLink + "' target='_self' class='content_NextFiletxt'>" + xTitle + "</a>";
            return mStr;
        }
        #endregion

        #region [GetLastDir]回傳上一個資料夾的連結，xLink為傳入的網址，xTitle為連結文字，return mStr為連結
        public string GetLastDir(string xLink, string xTitle)
        {
            //第一篇的連結為自身
            string mStr = "";
            int mintList = 0;
            if (pintDir == 1)
            { mintList = 1; }
            else
            { mintList = pintDir - 1; }
            xLink = xLink.Replace("@id_#", String.Format("{0:0000}", mintList));
            mStr = "<a href='" + xLink + "' target='_self' class='content_NextFiletxt'>" + xTitle + "</a>";
            return mStr;
        }
        #endregion

        #region 去日期、編號
        public string GetDateOut(string xStr)
        {
            if (xStr.Length < 12)
            {
                xStr = "";
            }
            else
            {
                xStr = xStr.Substring(12);
            }
            return xStr;
        }
        public string GetNumberOut(string xStr)
        {
            if (xStr.Length < 3)
            {
                xStr = "";
            }
            else
            {
                xStr = xStr.Substring(3);
            }
            return xStr;
        }
        #endregion

        #region 取日期時間
        public string GetCreatTime(string xPath)
        {
            string mTime = "";
            if (File.Exists(xPath))
            {
                DateTime mDateTime = File.GetCreationTime(xPath);
                mDateTime = GetDateTimeToTWDateTime(mDateTime);
                mTime = mDateTime.ToString();
            }
            return mTime;
        }
        public string GetTransactionTime(string xPath)
        {
            string mTime = "";
            if (File.Exists(xPath))
            {
                DateTime mCreatTime = File.GetCreationTime(xPath);
                DateTime mLastTime = File.GetLastWriteTime(xPath);
                if(mCreatTime < mLastTime)
                {
                    mLastTime = GetDateTimeToTWDateTime(mLastTime);
                    mTime = mLastTime.ToString();
                }
            }
            return mTime;
        }

        public DateTime GetDateTimeToTWDateTime(DateTime xDateTime)
        {
            //TimeZoneInfo mUS_TimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
            TimeZoneInfo mTW_TimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Taipei Standard Time");
            DateTime mTWDateTime = TimeZoneInfo.ConvertTime( xDateTime, TimeZoneInfo.Local, mTW_TimeZoneInfo);
            return mTWDateTime;
        }
        #endregion
    }
}