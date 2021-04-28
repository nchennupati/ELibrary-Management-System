using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityLayer;
using BusinessLogicLayer;
using ExceptionLayer;
namespace WebApplication1
{
    /// <summary>
    /// Class to facilitate home page activities
    /// </summary>
    public partial class AdminHomePage : System.Web.UI.Page
    {
        #region Page load method
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserObj"] == null)
                Response.Redirect("Home.aspx");
            if (!IsPostBack)
            {
                try
                {
                    UserDetails user = (UserDetails)Session["UserObj"];
                    lblWelcome.Text = "Welcome " + user.FirstName + " " + user.LastName;
                    ELibraryDocumentBL docBL = new ELibraryDocumentBL();
                    ELibraryPurchasedBL purchaseBL = new ELibraryPurchasedBL();
                    ELibraryUserBL userBL = new ELibraryUserBL();

                    lblReg.Text = userBL.GetRegisteredUserCountBL().ToString() + " Registered Users!!";
                    lblSub.Text = userBL.GetSubscribedUserCountBL().ToString() + " Subscribed Users!!";
                    lblSold.Text = purchaseBL.GetPurchasedCountBL().ToString() + " Documents Sold!!";
                }
                catch (Exception ex)
                {
                    ErrorLogging erLog = new ErrorLogging();
                    erLog.LogError(ex.Message);
                }
            }
        }
        #endregion
    }
}