using System;
using System.Collections.Generic;
using System.Data;
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
    /// Class For Shopping Cart Of The Subscriber
    /// </summary>
    public partial class ShoppingCart_Subscriber : System.Web.UI.Page
    {
        static List<int> docIDList=new List<int>();
        double amount = 0;
        double discountedAmount = 0;
        #region On page load Displays the cart items of the Subscriber
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserObj"] == null)
                Response.Redirect("Home.aspx");
            try
            {
                if (!IsPostBack)
                    DisplayCartItems();
            }
            catch (Exception ex)
            {
                ErrorLogging erLog = new ErrorLogging();
                erLog.LogError(ex.Message);
            }
        }
        #endregion
        #region Method To Display The Cart Items
        private void DisplayCartItems()
        {
            ELibraryDocumentBL docBLObj = new ELibraryDocumentBL();
            amount = 0;
            discountedAmount = 0;
            gvShoppingCart.DataSource = null;
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Title", typeof(string)));
            dt.Columns.Add(new DataColumn("Author", typeof(string)));
            dt.Columns.Add(new DataColumn("Description", typeof(string)));
            dt.Columns.Add(new DataColumn("Type", typeof(string)));
            dt.Columns.Add(new DataColumn("Price", typeof(string)));
            dt.Columns.Add(new DataColumn("", typeof(Control)));
            dt.Columns.Add(new DataColumn("Path", typeof(string)));
            dt.Columns.Add(new DataColumn("DocumentID", typeof(string)));
            if(Session["DocList"]!=null)
            { 
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
                    amount += doc.Price;
                    discountedAmount += .8 * doc.Price;
                }

            }
            gvShoppingCart.DataSource = dt;
            gvShoppingCart.DataBind();
            lblTotalAmountDisplay.Text = amount.ToString();
            lblDiscountAvail.Text = discountedAmount.ToString();
        }
        #endregion



        #region Method To Remove The Document From Cart
        protected void gvShoppingCart_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
        #endregion
        /// <summary>
        /// removes document from the cart
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        protected void gvShoppingCart_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Remove")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvShoppingCart.Rows[index];
                int docID = Convert.ToInt32(row.Cells[7].Text);
                docIDList.Remove(docID);
                Session["DocList"] = docIDList;
                DisplayCartItems();
            }
        }
        /// <summary>
        /// takes user to the payment form along with the payment object
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region  pay
        protected void btnpay_Click1(object sender, EventArgs e)
        {
            try
            {
                if (docIDList.Count == 0)
                    throw new ELibraryException("Cart Empty");
              
                Session["Amount"] = lblDiscountAvail.Text;
                UserDetails user = (UserDetails)Session["UserObj"];
                Session["UserId"] = user.UserID;
                Session["Subscribe"] = false;
                docIDList = null;
                Response.Redirect("PaymentForm.aspx");

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