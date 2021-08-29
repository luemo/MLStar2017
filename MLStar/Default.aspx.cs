using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MLStar.App_Code;

namespace MLStar
{
    public partial class Home : System.Web.UI.Page
    {
        #region 共用變數
        Sys pSys = new Sys();
        Fun pFun = new Fun();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                pSys.SetVisitorCount();
            }
            catch (Exception ex)
            {
                pSys.WriteErrorLog(ex.ToString(), pSys.GetRawUrl(Context));
            }
        }
    }
}