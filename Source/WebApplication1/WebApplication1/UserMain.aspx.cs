using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using EntityLayer;
using System.Data;



namespace WebApplication1
{
    /// <summary>
    /// User Home Class After User LogsIn
    /// </summary>
    public partial class UserHome1 : System.Web.UI.Page
    {
        #region On page load displays the recent documents added 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserObj"] == null)
                Response.Redirect("Home.aspx");
            try
            {
                if (!IsPostBack)
                {
                    GetBooksBought();
                    GetRecentDocumentByDiscipline();
                }
            }
            catch (Exception ex)
            {
                ErrorLogging erLog = new ErrorLogging();
                erLog.LogError(ex.Message);
            }

        }
        #endregion
        #region Method To GetRecentDocument added
        private void GetRecentDocumentByDiscipline()
        {
            ELibraryDocumentBL docBL = new ELibraryDocumentBL();
            UserDetails userObj = (UserDetails)Session["UserObj"];
            string AreaOfInterest = userObj.AreaOfInterest;
            string[] AreaOfInterestArray = AreaOfInterest.Split(',');
            List<DocumentDetails> docList = new List<DocumentDetails>();
            for (int i = 0; i < AreaOfInterestArray.Count(); i++)
            {
                
                string discName = AreaOfInterestArray[i];
                if (discName == "")
                    continue;
                docList.AddRange(docBL.GetRecentDocumentByDisciplineBL(discName));
            }
            gvBooksInterested.DataSource = null;
            if (docList.Count!=0)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("Title", typeof(string)));
                dt.Columns.Add(new DataColumn("Author", typeof(string)));
                //dt.Columns.Add(new DataColumn("Description", typeof(string)));
                dt.Columns.Add(new DataColumn("Price", typeof(string)));
                foreach (DocumentDetails doc in docList)
                {
                    
                    DataRow dr = dt.NewRow();
                    dr["Title"] = doc.Title;
                    dr["Author"] = doc.Author;
                    //dr["Description"] = doc.DocumentDescription;
                    dr["Price"] = doc.Price;
                    dt.Rows.Add(dr);
                }
                gvBooksInterested.DataSource = docList;
                gvBooksInterested.DataBind();

            }
           
            

        }
        #endregion

        #region Method To displat the books bought the user
        private void GetBooksBought()
        {
            ELibraryDocumentBL docBL = new ELibraryDocumentBL();
            UserDetails userObj =(UserDetails)Session["UserObj"];
            List<int> docIDList = docBL.GetDocumentsBoughtBL(userObj.UserID);
            gvPurchased.DataSource = null;
            if (docIDList != null)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("Title", typeof(string)));
                dt.Columns.Add(new DataColumn("Author", typeof(string)));
                dt.Columns.Add(new DataColumn("Description", typeof(string)));
                dt.Columns.Add(new DataColumn("Price", typeof(string)));
                
                foreach (int docId in docIDList)
                {
                    DocumentDetails doc = docBL.GetDocumentByID(docId);
                    DataRow dr = dt.NewRow();
                    dr["Title"] = doc.Title;
                    dr["Author"] = doc.Author;
                    dr["Description"] = doc.DocumentDescription;
                    dr["Price"] = doc.Price;
                    dt.Rows.Add(dr);
                }
                gvPurchased.DataSource = dt;
                gvPurchased.DataBind();
            }
        }
        #endregion


        protected void gvPurchased_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPurchased.PageIndex = e.NewPageIndex;
            GetBooksBought();
          

        }

        protected void gvBooksInterested_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvBooksInterested.PageIndex = e.NewPageIndex;
            GetRecentDocumentByDiscipline();
        }
    }
}
    
    


    
    

