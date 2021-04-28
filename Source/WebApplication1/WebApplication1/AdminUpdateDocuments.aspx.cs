using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityLayer;
using ExceptionLayer;
using BusinessLogicLayer;
using System.IO;

namespace WebApplication1
{
    /// <summary>
    /// Class to facilitate updation of documents
    /// </summary>
    public partial class AdminUpdateDocuments : System.Web.UI.Page
    {
        #region Page load
        protected void Page_Load(object sender, EventArgs e)
        {

            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (Session["UserObj"] == null)
                Response.Redirect("Home.aspx");
            InitializeCombo();
        }
        #endregion


        #region method to populate drop down lists
        private void InitializeCombo()
        {
            ELibraryDocumentBL docBL = new ELibraryDocumentBL();
            ELibraryPurchasedBL purchaseBL = new ELibraryPurchasedBL();
            ELibraryUserBL userBL = new ELibraryUserBL();

            //lblRegUsers.Content = userBL.GetRegisteredUserCountBL().ToString() + " Registered Users!!";
            //lblSubUsers.Content = userBL.GetSubscribedUserCountBL().ToString() + " Subscribed Users!!";
            // lblSoldDocs.Content = purchaseBL.GetPurchasedCountBL().ToString() + " Documents Sold!!";

            cboDiscipline.Items.Clear();

            cboDocumentType.Items.Clear();
            //cbDocTypeUpd.Items.Clear();
            cbnDocumentID.Items.Clear();


            foreach (Disciplines disc in docBL.GetAllDisciplinesBL())
            {
                cboDiscipline.Items.Add(disc.DisciplineName.ToString());

            }
            foreach (DocumentTypeDetails docType in docBL.GetAllDocumentTypesBL())
            {
                cboDocumentType.Items.Add(docType.DocumentTypeName.ToString());

            }
            if (docBL.GetAllDocumentIDBL() != null)
                foreach (int i in docBL.GetAllDocumentIDBL())
                {
                    cbnDocumentID.Items.Add(Convert.ToString(i));
                }
        }
        #endregion


        #region button click to update the document
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            DocumentDetails docObj = new DocumentDetails();
            ELibraryDocumentBL docBLObj = new ELibraryDocumentBL();
            try
            {
                InitializeCombo();
                if (cbnDocumentID.SelectedIndex == -1)
                {
                    throw new ELibraryException("Select Document ID");
                }

                if (cboDocumentType.SelectedIndex == -1)
                    throw new ELibraryException("Select Discipline");
                if (cboDiscipline.SelectedIndex == -1)
                    throw new ELibraryException("Select Document Type");

                docObj.DocumentID = Convert.ToInt32(cbnDocumentID.SelectedValue);
                //Session["DocumentId"] = cbnDocumentID.SelectedValue;
                string folderPath = Server.MapPath("~/Files/");
                if (!Directory.Exists(folderPath))
                {
                    //If Directory (Folder) does not exists. Create it.
                    Directory.CreateDirectory(folderPath);
                }

                string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                if (fileName == "")
                    throw new ELibraryException("Select File");
                FileUpload1.SaveAs(folderPath + Path.GetFileName(FileUpload1.FileName));
                docObj.DocumentPath = folderPath + Path.GetFileName(FileUpload1.FileName);

                docObj.DocumentName = txtDocumentName.Text;
                docObj.DocumentDescription = txtDescription.Text;
               
                docObj.DocumentTypeID = docBLObj.GetDocumentTypeIDBL(cboDocumentType.SelectedItem.ToString());
                docObj.DisciplineID = docBLObj.GetDisciplineIDBL(cboDiscipline.SelectedItem.ToString());
                docObj.Title = txtTitle.Text;
                docObj.Author = txtAuthor.Text;
                double price;
                bool isValidPrice = double.TryParse(txtPrice.Text, out price);
                if (!isValidPrice)
                    throw new ELibraryException("Invalid price");
                docObj.Price = price;
                docObj.UploadDate = DateTime.Today;

                if (docBLObj.UpdateDocumentBL(docObj))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Successfully Updated')", true);
                    //string str = "<script>alert(\"Updated Successfully\");</script>";
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Updation Failed')", true);
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

        #region button click to delete document
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            DocumentDetails docObj = new DocumentDetails();
            ELibraryDocumentBL docBLObj = new ELibraryDocumentBL();
            try
            {
                if (cbnDocumentID.SelectedIndex == -1)
                    throw new ELibraryException("Select Document ID");
                docObj.DocumentID = Convert.ToInt32(cbnDocumentID.SelectedValue);
                if (docBLObj.DeleteDocumentBL(docObj))
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Successfully Deleted')", true);
                else
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Deletion Failed')", true);
                InitializeCombo();
            }
            catch (ELibraryException ex)
            {
                ErrorLogging erLog = new ErrorLogging();
                erLog.LogError(ex.Message);
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message + "')", true);
            }
        }
        #endregion


        #region button click to reset fields
        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtDocumentName.Text = "";
            txtDescription.Text = "";
            lblPath.Text = "";
            cboDocumentType.SelectedIndex = -1;
            cboDiscipline.SelectedIndex = -1;
            txtTitle.Text = "";
            txtAuthor.Text = "";
            txtPrice.Text = "";
        }
        #endregion

        #region Fetch document details on index change
        protected void cbnDocumentID_SelectedIndexChanged(object sender, EventArgs e)
        {

            DropDownList cb = (DropDownList)sender;
            DocumentDetails docObj = null;
            ELibraryDocumentBL docBLObj = new ELibraryDocumentBL();
            try
            {
                if (cb.SelectedIndex == -1)
                    throw new ELibraryException("Please select Document ID");
                docObj = docBLObj.GetDocumentByID(Convert.ToInt32(cb.SelectedValue));
                if (docObj == null)
                    throw new ELibraryException("Document doesnt exist");

                txtDocumentName.Text = docObj.DocumentName;
                txtDescription.Text = docObj.DocumentDescription;
                
                txtTitle.Text = docObj.Title;
                txtAuthor.Text = docObj.Author;
                cboDocumentType.SelectedValue = docBLObj.GetDocumentTypeBL(docObj.DocumentTypeID).ToString();
                cboDiscipline.SelectedValue = docBLObj.GetDisciplineNameBL(docObj.DisciplineID);


                txtPrice.Text = docObj.Price.ToString();
            }
            catch (ELibraryException ex)
            {
                ErrorLogging erLog = new ErrorLogging();
                erLog.LogError(ex.Message);
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + ex.Message + "')", true);

            }

        }
        #endregion
    }
}
            
    
