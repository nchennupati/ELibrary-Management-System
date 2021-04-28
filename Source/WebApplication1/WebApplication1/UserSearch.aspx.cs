using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using EntityLayer;
using ExceptionLayer;
using System.Data;
using System.IO;

namespace WebApplication1
{
    /// <summary>
    /// Class For User Search
    /// </summary>
    public partial class UserSearch : System.Web.UI.Page
    {
        static List<int> docIDList = null;
        #region On pageload displays the disciplines
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserObj"] == null)
                Response.Redirect("Home.aspx");
            ELibraryDocumentBL docBL = new ELibraryDocumentBL();
            lblDisplay.Text = "";
            docIDList = new List<int>();
            if (Session["DocList"] != null)
                docIDList = (List<int>)Session["DocList"];
            DisplayCart();
            if (!IsPostBack)
            {
                foreach (Disciplines disc in docBL.GetAllDisciplinesBL())
                {
                    cboDiscipline.Items.Add(disc.DisciplineName.ToString());
                }

            }
        }
        #endregion
        #region Button to search document
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
                        dt.Columns.Add(new DataColumn("DocumentID", typeof(string)));
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
                        dt.Columns.Add(new DataColumn("DocumentID", typeof(string)));
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
                        gvSearch.DataSource = dt;
                        gvSearch.DataBind();
                    }
                }
            }
            catch (ELibraryException ex)
            {
                ErrorLogging erLog = new ErrorLogging();
                erLog.LogError(ex.Message);
                lblDisplay.Text = ex.Message;
            }


        }
        #endregion
        
        protected void gvSearch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #region Button For Downloading and adding to cart
        protected void gvSearch_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var row = (DataRowView)e.Row.DataItem;
                var docType = e.Row.Cells[4].Text;
                if (docType == "Freebie")
                {
                    var btnDownload = (Button)e.Row.FindControl("btnDownload");
                    var btnAddToCart = (Button)e.Row.FindControl("btnAddToCart");
                    btnAddToCart.Visible = false;
                    btnDownload.Visible = true;
                }
                else
                {
                    var btnDownload = (Button)e.Row.FindControl("btnDownload");
                    var btnAddToCart = (Button)e.Row.FindControl("btnAddToCart");
                    btnAddToCart.Visible = true;
                    btnDownload.Visible = false;
                }
            }

        }
        #endregion
        #region Button For Downloading
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
            if (e.CommandName == "AddToCart")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvSearch.Rows[index];
                int docID = Convert.ToInt32(row.Cells[7].Text);
                docIDList.Add(docID);
                Session["DocList"] = docIDList;
                DisplayCart();
            }
        }

        private void DisplayCart()
        {
            ELibraryDocumentBL docBLObj = new ELibraryDocumentBL();
            gvShoppingCart.DataSource = null;
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Title", typeof(string)));
            dt.Columns.Add(new DataColumn("Author", typeof(string)));
            dt.Columns.Add(new DataColumn("Price", typeof(string)));
            dt.Columns.Add(new DataColumn("", typeof(Control)));
            dt.Columns.Add(new DataColumn("DocumentID", typeof(string)));
            if (Session["DocList"] != null)
            {
                docIDList = (List<int>)Session["DocList"];
                foreach (int docID in docIDList)
                {
                    DocumentDetails doc = docBLObj.GetDocumentByID(docID);
                    DataRow dr = dt.NewRow();
                    dr["Title"] = doc.Title;
                    dr["Author"] = doc.Author;
                    dr["DocumentID"] = doc.DocumentID;

                    dr["Price"] = doc.Price;
                  
                    dt.Rows.Add(dr);
                   
                }

            }
            gvShoppingCart.DataSource = dt;
            gvShoppingCart.DataBind();
        }
        #endregion
        #region Button To Remove The Document From Cart
        protected void gvShoppingCart_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Remove")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvShoppingCart.Rows[index];
                int docID = Convert.ToInt32(row.Cells[4].Text);
                docIDList.Remove(docID);
                Session["DocList"] = docIDList;
                DisplayCart();
                
            }
        }
        #endregion
        #region Buy Button
        protected void btnBuy_Click(object sender, EventArgs e)
        {
            try
            {

                if (docIDList.Count == 0)
                {
                    throw new ELibraryException("Cart Empty");
                    //Response.Write("<script>alert('Please select atleast one checkbox')</script>");
                }
                Session["DocList"] = docIDList;
                docIDList = null;
                UserDetails user = (UserDetails)Session["UserObj"];
                if (user.UserType == "Subscriber")
                    Response.Redirect("ShoppingCart_Subscriber.aspx");
                if (user.UserType == "Non subscriber")
                    Response.Redirect("ShoppingCart_NonSubscriber.aspx");

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