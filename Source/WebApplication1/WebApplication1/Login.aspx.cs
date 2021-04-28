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
    /// Class facilitating user login
    /// </summary>
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region login button click
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string userId = txtUserID.Text;
            string password = txtPassword.Text;

            try
            {
                
                UserDetails userObj;
                ELibraryUserBL userBL = new ELibraryUserBL();
                userObj = userBL.UserLoginBL(userId, password);
                if (userObj != null)
                {
                    Session["UserObj"] = userObj;
                    if (userObj.UserType == "Admin")
                    {

                        Response.Redirect("AdminHomePage.aspx");

                    }
                    else
                    {

                        Response.Redirect("UserMain.aspx");
                    }

                }
                else
                {
                    lblStatus.Text = "Incorrect UserId/Password";
                    throw new ELibraryException("Invalid login");
                }
            }
            catch (ELibraryException ex)
            {
                lblStatus.Text = ex.Message;
                ErrorLogging erLog = new ErrorLogging();
                erLog.LogError(ex.Message);
            }
        }
        #endregion
    }
}