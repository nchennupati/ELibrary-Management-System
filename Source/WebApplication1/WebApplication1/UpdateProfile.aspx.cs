using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityLayer;
using ExceptionLayer;
using BusinessLogicLayer;

using System.Text;

namespace WebApplication1
{
    /// <summary>
    /// Class To Update The Profile
    /// </summary>
    public partial class UpdateProfile : System.Web.UI.Page
    {
        #region page_load displays the details of the user
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserObj"] == null)
                Response.Redirect("Home.aspx");
            if (!IsPostBack)
            {
                ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

                UserDetails user = new UserDetails();
                ELibraryDocumentBL bllobj = new ELibraryDocumentBL();
                //Session["userid"] = user.UserID;
                UserDetails userobj = (UserDetails)Session["UserObj"];
                //UserDetails entityobj = bllobj.GetDetailsUserBL(userobj.UserID);
                lblwelcome.Text = "Welcome " + userobj.FirstName;
                txtfirstname.Text = userobj.FirstName;
                txtlastname.Text = userobj.LastName;
                txtpwd.Text = userobj.Pasword;

                txtlandnum.Text = userobj.LandLineNumber;
                txtmblnum.Text = userobj.MobileNumber;
                txtadress.Text = userobj.UserAddress.ToString();


                foreach (Disciplines disc in bllobj.GetAllDisciplinesBL())
                {
                    chklAreasofInterest.Items.Add(disc.DisciplineName.ToString());
                }

                string AreaOfInterest = userobj.AreaOfInterest;
                string[] AreaOfInterestArray = AreaOfInterest.Split(',');
                foreach (string str in AreaOfInterestArray)
                {
                    for (int i = 0; i < chklAreasofInterest.Items.Count; i++)
                    {
                        if (chklAreasofInterest.Items[i].Text == str)
                        {

                            chklAreasofInterest.Items[i].Selected = true;
                        }
                    }




                }
            }
        }
        #endregion
        #region Button Click Updates The Changes Made By The User
        public void Button1_Click(object sender, EventArgs e)

        {
            StringBuilder sb = new StringBuilder();

            ELibraryUserBL bllobj = new ELibraryUserBL();
            UserDetails userUpdateObj = new UserDetails();
            ELibraryDocumentBL docBl = new ELibraryDocumentBL();
            UserDetails userobj = (UserDetails)Session["UserObj"];
            userUpdateObj.UserID = userobj.UserID;
            userUpdateObj.Pasword = txtpwd.Text;
            userUpdateObj.FirstName = txtfirstname.Text;
            userUpdateObj.LastName = txtlastname.Text;
            userUpdateObj.LandLineNumber = txtlandnum.Text;
            userUpdateObj.MobileNumber = txtmblnum.Text;
            userUpdateObj.UserAddress = txtadress.Text;
            for (int i = 0; i < chklAreasofInterest.Items.Count; i++)
            {

                if (chklAreasofInterest.Items[i].Selected)
                {

                    int j = 0;
                    j = i + 1;
                    var name = docBl.GetDisciplineNameBL(j);
                    sb.Append(name + ",");
                }
                userUpdateObj.AreaOfInterest = sb.ToString();



                //userUpdateObj.AreaOfInterest = chklAreasofInterest.SelectedValue.ToString();
                bool isUpdated = bllobj.UpdateDetailsUserBL(userUpdateObj);
                if (isUpdated)
                {
                    lblupdatestatus.Text = "Successfully Updated";
                    Session["UserObj"] = userUpdateObj;
                }
                else
                {
                    lblupdatestatus.Text = "Not Updated Properly";
                }





            }
        }
        #endregion
    }
}