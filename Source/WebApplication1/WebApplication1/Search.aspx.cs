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
    /// Class For Search
    /// </summary>
    public partial class Search : System.Web.UI.Page
    {
        #region page_load to add disciplines to the CheckList
        protected void Page_Load(object sender, EventArgs e)
        {
            ELibraryDocumentBL docBL = new ELibraryDocumentBL();
            if (!IsPostBack)
            {
                foreach (Disciplines disc in docBL.GetAllDisciplinesBL())
                {
                    cboDiscipline.Items.Add(disc.DisciplineName.ToString());
                }
                
            }
        }
        #endregion
        #region Button To Search By name or Discipline
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ELibraryDocumentBL docBL = new ELibraryDocumentBL();
            List<DocumentDetails> documentList = null;
            try
            {
                if (cboSearchBy.SelectedItem.Text == "Name")
                {
                    gvSearch.DataSource = null;
                    string name = txtName.Text;
                    if (name == "")
                        throw new ELibraryException("Please enter the name");
                    documentList = docBL.ViewDocumentsByNameBL(name);
                    if (documentList != null)
                    {
                        DataTable dt = new DataTable();
                        dt.Columns.Add(new DataColumn("Title", typeof(string)));
                        dt.Columns.Add(new DataColumn("Author", typeof(string)));
                        dt.Columns.Add(new DataColumn("Description", typeof(string)));
                        dt.Columns.Add(new DataColumn("Type", typeof(string)));
                        dt.Columns.Add(new DataColumn("Price", typeof(string)));
                        dt.Columns.Add(new DataColumn("", typeof(Control)));
                        dt.Columns.Add(new DataColumn("Path", typeof(string)));
                        foreach (DocumentDetails doc in documentList)
                        {
                            DataRow dr = dt.NewRow();
                            dr["Title"] = doc.Title;
                            dr["Author"] = doc.Author;
                            dr["Type"] = docBL.GetDocumentTypeBL(doc.DocumentTypeID);
                            dr["Description"] = doc.DocumentDescription;
                            dr["Path"] = doc.DocumentPath;
                            dr["Price"] = doc.Price;
                            dt.Rows.Add(dr);
                        }
                        gvSearch.DataSource = dt;
                        gvSearch.DataBind();
                    }
                }
                else if (cboSearchBy.SelectedItem.Text == "Discipline")
                {
                    gvSearch.DataSource = null;
                    string discipline = cboDiscipline.SelectedItem.Text;
                   
                    documentList = docBL.ViewDocumentsByDisciplineBL(discipline);
                    if (documentList != null)
                    {
                        DataTable dt = new DataTable();
                        dt.Columns.Add(new DataColumn("Title", typeof(string)));
                        dt.Columns.Add(new DataColumn("Author", typeof(string)));
                        dt.Columns.Add(new DataColumn("Description", typeof(string)));
                        dt.Columns.Add(new DataColumn("Type", typeof(string)));
                        dt.Columns.Add(new DataColumn("Price", typeof(string)));
                        dt.Columns.Add(new DataColumn("", typeof(Control)));
                        dt.Columns.Add(new DataColumn("Path", typeof(string)));
                        foreach (DocumentDetails doc in documentList)
                        {
                            DataRow dr = dt.NewRow();
                            dr["Title"] = doc.Title;
                            dr["Author"] = doc.Author;
                            dr["Type"] = docBL.GetDocumentTypeBL(doc.DocumentTypeID);
                            dr["Description"] = doc.DocumentDescription;
                            dr["Path"] = doc.DocumentPath;
                            dr["Price"] = doc.Price;
                            dt.Rows.Add(dr);
                        }
                        gvSearch.DataSource = dt;
                        gvSearch.DataBind();
                    }
                }
            }
            catch (ELibraryException ex)
            {
                lblDisplay.Text = ex.Message;
                ErrorLogging erLog = new ErrorLogging();
                erLog.LogError(ex.Message);
            }
        }
        #endregion
        #region Add Button/Label To GridRow For Download a Message
        protected void gvSearch_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var row = (DataRowView)e.Row.DataItem;
                var docType = e.Row.Cells[4].Text;
                if (docType == "Freebie")
                {
                    var btn = (Button)e.Row.FindControl("btnDownload");
                    var lbl = (Label)e.Row.FindControl("lblBuy");
                    lbl.Visible = false;
                    btn.Visible = true;
                }
                else
                {
                    var btn = (Button)e.Row.FindControl("btnDownload");
                    var lbl = (Label)e.Row.FindControl("lblBuy");
                    lbl.Visible = true;
                    btn.Visible = false;
                }
            }
        }
        #endregion
        #region To Allow User To Download On Cllick Of Button
        protected void gvSearch_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Download")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvSearch.Rows[index];
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