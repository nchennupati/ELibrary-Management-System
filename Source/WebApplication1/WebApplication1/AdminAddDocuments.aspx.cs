using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityLayer;
using BusinessLogicLayer;
using ExceptionLayer;
using System.IO;

namespace WebApplication1
{
    public partial class AdminAddDocuments : System.Web.UI.Page
    {
        #region Page load method calling initialize method
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserObj"] == null)
                Response.Redirect("Home.aspx");
            if(!IsPostBack)
            {
                InitializeCombo();
            }
        }
        #endregion


        #region populates the dropdownlist 
        private void InitializeCombo()
        {
            ELibraryDocumentBL docBL = new ELibraryDocumentBL();
            ELibraryPurchasedBL purchaseBL = new ELibraryPurchasedBL();
            ELibraryUserBL userBL = new ELibraryUserBL();

            //lblRegUsers.Content = userBL.GetRegisteredUserCountBL().ToString() + " Registered Users!!";
            //lblSubUsers.Content = userBL.GetSubscribedUserCountBL().ToString() + " Subscribed Users!!";
            //lblSoldDocs.Content = purchaseBL.GetPurchasedCountBL().ToString() + " Documents Sold!!";

            cboDiscipline.Items.Clear();
            cboDocumentType.Items.Clear();

            foreach (Disciplines disc in docBL.GetAllDisciplinesBL())
            {
                cboDiscipline.Items.Add(disc.DisciplineName.ToString());
            }
            foreach (DocumentTypeDetails docType in docBL.GetAllDocumentTypesBL())
            {
                cboDocumentType.Items.Add(docType.DocumentTypeName.ToString());
            }
        }
        #endregion

        #region button click event to add document
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            DocumentDetails docObj = new DocumentDetails();
            ELibraryDocumentBL docBLObj = new ELibraryDocumentBL();
            try
            {
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
                

                if (cboDocumentType.SelectedIndex == -1)
                    throw new ELibraryException("Invalid Document Type");
                docObj.DocumentTypeID = docBLObj.GetDocumentTypeIDBL(cboDocumentType.SelectedItem.ToString());

                if (cboDiscipline.SelectedIndex == -1)
                    throw new ELibraryException("Invalid Discipline");
                docObj.DisciplineID = docBLObj.GetDisciplineIDBL(cboDiscipline.SelectedItem.ToString());

                docObj.Title = txtTitle.Text;
                docObj.Author = txtAuthor.Text;
                double price;
                bool isValidPrice = double.TryParse(txtPrice.Text, out price);
                if (!isValidPrice)
                    throw new ELibraryException("Invalid price");
                docObj.Price = price;
                docObj.UploadDate = DateTime.Today;

                if (docBLObj.AddNewDocumentBL(docObj))
                {
                    lblDisplay.Text = "Added";      //.Show("Added");
                }
                else
                    lblDisplay.Text = "Failed";
                InitializeCombo();
            }
            catch (ELibraryException ex)
            {
                lblDisplay.Text = ex.Message;
            }
        }
        #endregion


        #region button click to reset the fields
        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtDocumentName.Text = "";
            txtDescription.Text = "";
          
            cboDocumentType.SelectedIndex = -1;
            cboDiscipline.SelectedIndex = -1;
            txtTitle.Text = "";
            txtAuthor.Text = "";
            txtPrice.Text = "";
        }
        #endregion
    }
}