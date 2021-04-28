using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityLayer;
using BusinessLogicLayer;
using ExceptionLayer;
using System.Text;

namespace WebApplication1
{
    /// <summary>
    /// Class for registration
    /// </summary>
    public partial class Register : System.Web.UI.Page
    {
        #region page load to populate checklist
        protected void Page_Load(object sender, EventArgs e)
        {
            ELibraryDocumentBL docBL = new ELibraryDocumentBL();
            
            if (!IsPostBack)
            {
                foreach (Disciplines disc in docBL.GetAllDisciplinesBL())
                {
                    chklAreasofInterest.Items.Add(disc.DisciplineName.ToString());
                }
            }

        }
        #endregion

        #region register button click
        protected void btnRegister_Click(object sender, EventArgs e)
        {

            ELibraryDocumentBL docBL = new ELibraryDocumentBL();
            UserDetails userObj = new UserDetails();
            StringBuilder sb = new StringBuilder();
            try
            {
                userObj.UserID = txtUserId.Text;
                Session["UserId"] = userObj.UserID;
                userObj.FirstName = txtFirstName.Text;
                userObj.LastName = txtLastName.Text;
                DateTime dob;
                bool isValidDate = DateTime.TryParse(txtDateOfBirth.Text, out dob);
                if (isValidDate)
                    userObj.DateOfBirth = dob;
                else
                    throw new ELibraryException("Please enter date of birth");

                if (rblGender.SelectedValue == "Male")

                    userObj.Gender = "M";

                else
                    userObj.Gender = "F";
                userObj.UserAddress = txtAddress.Text;
                userObj.LandLineNumber = txtLandlineNumber.Text;
                userObj.MobileNumber = txtboxMobileNumber.Text;
                userObj.Pasword = txtPassword.Text;

                

                for (int i = 0; i < chklAreasofInterest.Items.Count; i++)
                {
                    
                    if (chklAreasofInterest.Items[i].Selected)
                    {
                        
                        int j = 0;
                        j = i + 1;
                        var name = docBL.GetDisciplineNameBL(j);
                        sb.Append(name + ",");
                    }
                   

                }
                int itemsSelected = 0;
                foreach (ListItem li in chklAreasofInterest.Items)
                {
                    if (li.Selected)
                    {
                        itemsSelected = itemsSelected + 1;
                    }
                }
                if (itemsSelected == 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please select atleast one checkbox')", true);
                    //Response.Write("<script>alert('Please select atleast one checkbox')</script>");
                }



                userObj.AreaOfInterest = sb.ToString();

                userObj.DateOfRegistration = DateTime.Now;
                userObj.UserType = "Non Scubscriber";

                ELibraryUserBL userBL = new ELibraryUserBL();

                bool isAdded = userBL.RegisterBL(userObj);
                if (isAdded)
                    lblException.Text = "Registered";
                if (chksubscribe.Checked == true)
                {
                    Session["Amount"] = 1000;
                    Session["Subscribe"] = true;
                    PaymentForm payForm = new PaymentForm();
                    Response.Redirect("PaymentForm.aspx");

                }


            }
            catch (ELibraryException ex)
            {
                ErrorLogging erLog = new ErrorLogging();
                erLog.LogError(ex.Message);
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('"+ex.Message+"')", true);

            }

        }
        #endregion
    }
}