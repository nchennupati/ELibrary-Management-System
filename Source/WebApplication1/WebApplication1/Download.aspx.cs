using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityLayer;
using BusinessLogicLayer;
using ExceptionLayer;
using System.Data;
using System.IO;

namespace WebApplication1
{
    public partial class Download : System.Web.UI.Page
    {
        #region Page load calls method to populate cart grid
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {

                    DownloadCartItems();
                }
            }
            catch (Exception ex)
            {
                ErrorLogging erLog = new ErrorLogging();
                erLog.LogError(ex.Message);
            }
        }
        #endregion


        # region method to populate cart grid
        private void DownloadCartItems()
        {
            ELibraryDocumentBL docBLObj = new ELibraryDocumentBL();
            List<int> docIDList = (List<int>)Session["DocList"];
            gvDownload.DataSource = null;
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Title", typeof(string)));
            dt.Columns.Add(new DataColumn("Author", typeof(string)));
            dt.Columns.Add(new DataColumn("Description", typeof(string)));
            dt.Columns.Add(new DataColumn("Type", typeof(string)));
            dt.Columns.Add(new DataColumn("Price", typeof(string)));
            dt.Columns.Add(new DataColumn("", typeof(Control)));
            dt.Columns.Add(new DataColumn("Path", typeof(string)));
            dt.Columns.Add(new DataColumn("DocumentID", typeof(string)));
            docIDList = (List<int>)Session["DocList"];
            foreach (int docID in docIDList)
            {
                DocumentDetails doc = docBLObj.GetDocumentByID(docID);
                DataRow dr = dt.NewRow();
                dr["Title"] = doc.Title;
                dr["Author"] = doc.Author;
                dr["Type"] = docBLObj.GetDocumentTypeBL(doc.DocumentTypeID);
                dr["Description"] = doc.DocumentDescription;
                dr["Path"] = doc.DocumentPath;
                dr["Price"] = doc.Price;
                dr["DocumentID"] = doc.DocumentID;
                dt.Rows.Add(dr);
            }
            gvDownload.DataSource = dt;
            gvDownload.DataBind();
          
        }
        #endregion

        #region allows download of document on download button click
        protected void gvDownload_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Download")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvDownload.Rows[index];
                string path = row.Cells[5].Text;

                FileInfo fileInfo = new FileInfo(path);


                if (fileInfo.Exists)
                {
                    Response.ContentType = ContentType;
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(fileInfo.FullName));
                    Response.WriteFile(fileInfo.FullName);
                    Response.End();
                }

            }
        }
        #endregion

        #region Redirect to home
        protected void btnHome_Click(object sender, EventArgs e)
        {
            Session["DocList"] = null;
            Response.Redirect("UserMain.aspx");
        }
        #endregion
    }
}