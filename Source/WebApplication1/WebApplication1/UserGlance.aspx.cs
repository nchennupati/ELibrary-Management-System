using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using EntityLayer;
using ExceptionLayer;
namespace WebApplication1
{
    /// <summary>
    /// Glance Class Displaying The glance Of Documents Available
    /// </summary>
    public partial class Glance : System.Web.UI.Page
    {
        static List<int> docIDList = null;
        #region On page load displays Discplines available
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserObj"] == null)
                Response.Redirect("Home.aspx");
            try
            {
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
        #region Button To Filter according to Document
        protected void btnFilter_Click(object sender, EventArgs e)
        {
            try
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
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please select atleast one checkbox')", true);
                    //Response.Write("<script>alert('Please select atleast one checkbox')</script>");
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
                    btnBuy.Visible = true;
                }
            }
            catch (Exception ex)
            {
                ErrorLogging erLog = new ErrorLogging();
                erLog.LogError(ex.Message);
            }
        }
        #endregion

        #region For adding Download And AddToCart Buttons
        protected void gvGlance_RowDataBound(object sender, GridViewRowEventArgs e)
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
        #region Button For download and add to cart

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
            if (e.CommandName == "AddToCart")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvGlance.Rows[index];
                int docID = Convert.ToInt32(row.Cells[7].Text);
                docIDList.Add(docID);
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
                docIDList=null;
                UserDetails user = (UserDetails)Session["UserObj"];
                if (user.UserType == "Subscriber")
                    Response.Redirect("ShoppingCart_Subscriber.aspx");
                if (user.UserType == "Non subscriber")
                    Response.Redirect("ShoppingCart_NonSubscriber.aspx");

            }
            catch(ELibraryException ex)
            {
                ErrorLogging erLog = new ErrorLogging();
                erLog.LogError(ex.Message);
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('"+ex.Message+"')", true);
            }
        }
        #endregion
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
    }
}