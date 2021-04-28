using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    /// <summary>
    /// Class for logout
    /// </summary>
    public partial class LogOut : System.Web.UI.Page
    {
        #region logout
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["UserObj"] = null;
            Response.Redirect("Home.aspx");
        }
        #endregion
    }
}