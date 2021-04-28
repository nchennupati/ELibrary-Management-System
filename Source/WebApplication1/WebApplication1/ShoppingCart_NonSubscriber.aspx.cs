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

namespace WebApplication1
{
    /// <summary>
    /// Class For ShoppingCart Of NonSubscriber
    /// </summary>
    public partial class ShoppingCart_NonSubscriber : System.Web.UI.Page
    {
        static List<int> docIDList = new List<int>();
        double amount = 0;
        double discountedAmount = 0;
        #region on page_load displays the cart items
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
        #region Method to display the cartitems
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
            if (Session["DocList"] != null)
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
        #region Button To Remove The Document From Cart
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
                DisplaySubscription();
            }
        }
        #endregion
        #region Subscription CheckBox 
        protected void chkSubscriber_CheckedChanged(object sender, EventArgs e)
        {
            
           DisplaySubscription();
            
        }
        #endregion
        #region Method To Display The Subscription Amount
        private void DisplaySubscription()
        {
            lblSubscriptionAmount.Text = "";
            try
            {
                if (chkSubscriber.Checked == true)
                {
                    decimal totalSub = (1000 + Convert.ToDecimal(lblDiscountAvail.Text));
                    lblSubscriptionAmount.Text = "Subsciption Amount: 1000 " + " Total Amount With Subscription: " + totalSub.ToString();
                }
            }
            catch (Exception ex)
            {
                ErrorLogging erLog = new ErrorLogging();
                erLog.LogError(ex.Message);
            }
        }
        #endregion
        #region Pay Button Click
        protected void btnpay_Click(object sender, EventArgs e)
        {
          
            try
            {
                if (docIDList.Count == 0)
                    throw new ELibraryException("Cart Empty");
                if (chkSubscriber.Checked)
                {
                    Session["Amount"] = Convert.ToDecimal(lblDiscountAvail.Text) + 1000;
                    Session["Subscribe"] = true;
                }
                else
                {
                    Session["Amount"] = Convert.ToDecimal( lblTotalAmountDisplay.Text);
                    Session["Subscribe"] = false;
                }
                UserDetails user = (UserDetails)Session["UserObj"];
                Session["UserId"] = user.UserID;
               
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