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
    public partial class HomeMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //protected void btnLogin_Click(object sender, EventArgs e)
        //{
        //    string userId = txtUserID.Text;
        //    string password = txtPassword.Text;

        //    try
        //    {
        //        if(userId=="")
        //        {
        //            throw new ELibraryException("UserId empty");
        //        }
        //        if(password=="")
        //        {
        //            throw new ELibraryException("Password empty");
        //        }
        //        UserDetails userObj;
        //        ELibraryUserBL userBL = new ELibraryUserBL();
        //        userObj = userBL.UserLoginBL(userId, password);
        //        if (userObj != null)
        //        {
        //            Session["UserObj"] = userObj;
        //            if (userObj.UserType == "Admin")
        //            {

        //                Response.Redirect("~/AdminHomePage.aspx");

        //            }
        //            else
        //            {

        //                Response.Redirect("~/UserHomePage.aspx");
        //            }

        //        }
        //        else
        //        {
        //            lblStatus.Text = "Incorrect UserId/Password";
        //        }
        //    }
        //    catch (ELibraryException ex)
        //    {
        //        lblStatus.Text = ex.Message;
        //    }
        //}


    }
}