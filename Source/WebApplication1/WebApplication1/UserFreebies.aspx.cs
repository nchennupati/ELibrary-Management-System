using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using EntityLayer;
using System.Data;
using System.IO;

namespace WebApplication1
{
    /// <summary>
    /// UserFreebies Class To Display The Freebie Documents To the User
    /// </summary>
    public partial class UserFreebies : System.Web.UI.Page
    {
        #region On Page Load Displays The Freebie Documents Available To The User
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserObj"] == null)
                Response.Redirect("Home.aspx");
            try
            {
                if (!IsPostBack)
                {
                    ELibraryDocumentBL docBL = new ELibraryDocumentBL();
                    DataTable dt = new DataTable();
                    dt.Columns.Add(new DataColumn("Title", typeof(string)));
                    dt.Columns.Add(new DataColumn("Author", typeof(string)));
                    dt.Columns.Add(new DataColumn("Description", typeof(string)));
                    dt.Columns.Add(new DataColumn("Download", typeof(Control)));
                    dt.Columns.Add(new DataColumn("Path", typeof(string)));
                    List<DocumentDetails> docList = docBL.AccessDocumentsByTypeBL("Freebie");
                    if (docList != null)
                    {
                        foreach (DocumentDetails doc in docList)
                        {
                            DataRow dr = dt.NewRow();
                            dr["Title"] = doc.Title;
                            dr["Author"] = doc.Author;
                            dr["Description"] = doc.DocumentDescription;
                            dr["Path"] = doc.DocumentPath;
                            dt.Rows.Add(dr);
                        }
                        gvFreebies.DataSource = dt;
                        gvFreebies.DataBind();
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
        #region Button To Download The Documents
        protected void gvFreebies_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Download")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvFreebies.Rows[index];
                string path = row.Cells[4].Text;

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

        protected void gvFreebies_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //var row = (DataRowView)e.Row.DataItem;
                //var btn = (Button)e.Row.FindControl("btnDownload");
                //String path = (String)row["Path"];
                //btn.CommandArgument = path;
                ////btn.Attributes["path"] = path;
                ////btn.Click += DownloadHandler;

            }
        }
    }
}