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
    /// <summary>
    /// Class for payment
    /// </summary>
    public partial class PaymentForm : System.Web.UI.Page
    {
        #region page load
        protected void Page_Load(object sender, EventArgs e)
        {
            UserDetails userObj = new UserDetails();
            userObj.UserID = Session["UserId"].ToString();
            lbluID.Text = userObj.UserID;
            lblshowamt.Text = Session["Amount"].ToString();
            bool subscribe = (bool)Session["Subscribe"];
        }
        #endregion

        #region Pay button click
        protected void btnpay_Click(object sender, EventArgs e)
        {
            PaymentDetails paymentObj = new PaymentDetails();
            UserDetails userObj = new UserDetails();
            userObj.UserID = Session["UserId"].ToString();
            try
            {
                paymentObj.CreditCardNumber = txtcreditcard.Text;
                paymentObj.CreditCardName = txtname.Text;
                paymentObj.CVV = txtcvv.Text;


                if (ddlexpmonth.SelectedValue == null)
                    throw new ELibraryException("enter valid month");
                paymentObj.ExpiryMonth = Convert.ToInt32(ddlexpmonth.SelectedValue);
                int year;
                bool isYear = int.TryParse(txtexpyear.Text, out year);
                if (!isYear)
                    throw new ELibraryException("Enter Valid Year");
                paymentObj.ExpiryYear = year;
                ELibraryUserBL userBL = new ELibraryUserBL();
                ELibraryPaymentBL payBLObj = new ELibraryPaymentBL();
                ELibraryDocumentBL docBLObj = new ELibraryDocumentBL();
                if (payBLObj.VerifyPaymentBL(paymentObj))
                {
                  
                    if ((bool)Session["Subscribe"])
                    {
                        userBL.UpdateUserSubscriptionBL(userObj, paymentObj);
                        userObj.UserType = "Subscriber";
                        if(Session["UserObj"]!=null)
                        {
                            UserDetails user = (UserDetails)Session["UserObj"];
                            user.UserType = "Subscriber";
                            Session["UserObj"] = user;
                        }
                    }
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Payment successful\nPurchased documents will be in downloads.\nHappy Reading!!')", true);

                }
                List<int> docIDList = null;
                if (Session["DocList"]!=null)
                    docIDList = (List<int>)Session["DocList"];

                if (docIDList != null)
                {
                    ELibraryPurchasedBL purchaseBL = new ELibraryPurchasedBL();
                    foreach (int doc in docIDList)
                    {
                        PurchasedDetails purchase = new PurchasedDetails();
                        purchase.DocumentID = doc;
                        purchase.UserID = userObj.UserID;
                        purchase.PurchasedDate = DateTime.Today;
                        purchaseBL.PurchaseDocumentBL(purchase);
                       
                    }
                    Response.Redirect("Download.aspx");
                  
                }
                else
                {
                    Response.Redirect("Home.aspx");
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

        
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserMain.aspx");
        }
    }
}