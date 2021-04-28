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
    /// <summary>
    /// Class facilitating browsing all documents
    /// </summary>
    public partial class Glance1 : System.Web.UI.Page
    {
        #region page load to populate the checklist
        protected void Page_Load(object sender, EventArgs e)
        {
            ELibraryDocumentBL docBL = new ELibraryDocumentBL();
            
            List<int> docIDList = new List<int>();
            try
            {
                if (!IsPostBack)
                {
                    foreach (Disciplines disc in docBL.GetAllDisciplinesBL())
                    {
                        chklasideBar.Items.Add(disc.DisciplineName.ToString());
                    }

                }
            }
            catch (Exception ex)
            {
                ErrorLogging erLog = new ErrorLogging();
                erLog.LogError(ex.Message);
            }
        }
        #endregion

        #region filter button to fetch specific documents
        protected void btnFilter_Click(object sender, EventArgs e)
        {

            gvGlance.DataSource = null;
            lblDisplay.Text = "";
            List<DocumentDetails> documentList = new List<DocumentDetails>();
            ELibraryDocumentBL docBL = new ELibraryDocumentBL();
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Title", typeof(string)));
            dt.Columns.Add(new DataColumn("Author", typeof(string)));
            dt.Columns.Add(new DataColumn("Description", typeof(string)));
            dt.Columns.Add(new DataColumn("Type", typeof(string)));
            dt.Columns.Add(new DataColumn("Price", typeof(string)));
            dt.Columns.Add(new DataColumn("", typeof(Control)));
            dt.Columns.Add(new DataColumn("Path", typeof(string)));
            dt.Columns.Add(new DataColumn("DocumentID", typeof(string)));

            try
            {
                int itemsSelected = 0;
                foreach (ListItem li in chklasideBar.Items)
                {
                    if (li.Selected)
                    {
                        itemsSelected = itemsSelected + 1;
                    }
                }
                if (itemsSelected == 0)
                {
                    throw new ELibraryException("Please select a check box");
                }
                for (int i = 0; i < chklasideBar.Items.Count; i++)
                {


                    List<DocumentDetails> documentDiscList = null;

                    if (chklasideBar.Items[i].Selected)
                    {
                        documentDiscList = null;
                        string discipline = chklasideBar.Items[i].Text;
                        documentDiscList = docBL.ViewDocumentsByDisciplineBL(discipline);
                        if (documentDiscList != null)
                        {
                            foreach (DocumentDetails doc in documentDiscList)
                                documentList.Add(doc);
                        }

                    }
                }
                if (documentList.Count > 0)
                {

                    foreach (DocumentDetails doc in documentList)
                    {
                        DataRow dr = dt.NewRow();
                        dr["Title"] = doc.Title;
                        dr["Author"] = doc.Author;
                        dr["Type"] = docBL.GetDocumentTypeBL(doc.DocumentTypeID);
                        dr["Description"] = doc.DocumentDescription;
                        dr["Path"] = doc.DocumentPath;
                        dr["Price"] = doc.Price;
                        dr["DocumentID"] = doc.DocumentID;
                        dt.Rows.Add(dr);
                    }
                    gvGlance.DataSource = dt;
                    gvGlance.DataBind();

                }
            }
            catch(ELibraryException ex)
            {
                ErrorLogging erLog = new ErrorLogging();
                erLog.LogError(ex.Message);
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please select atleast one checkbox')", true);

            }
            catch (Exception ex)
            {
                ErrorLogging erLog = new ErrorLogging();
                erLog.LogError(ex.Message);
            }

        }
        #endregion

        #region add download button or label to grid row as required
        protected void gvGlance_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var row = (DataRowView)e.Row.DataItem;
                var docType = e.Row.Cells[4].Text;
                if (docType == "Freebie")
                {
                    var btnDownload = (Button)e.Row.FindControl("btnDownload");
                    var lblBuy = (Label)e.Row.FindControl("lblBuy");
                    lblBuy.Visible = false;
                    btnDownload.Visible = true;
                }
                else
                {
                    var btnDownload = (Button)e.Row.FindControl("btnDownload");
                    var lblBuy = (Label)e.Row.FindControl("lblBuy");
                    lblBuy.Visible = true;
                    btnDownload.Visible = false;
                }
            }
        }
        #endregion

        #region allow download of freebie document
        protected void gvGlance_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Download")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvGlance.Rows[index];
                string path = row.Cells[6].Text;

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
    }
}