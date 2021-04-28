using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using ExceptionLayer;
using System.Data;
using System.Data.Common;

namespace DataAccessLayer
{
    /// <summary>
    /// data access layer for documents
    /// </summary>
    public class ELibraryDocumentDAL
    {
        DbCommand commandObj;
        public List<DocumentDetails> GetRecentDocumentsByDisciplineDAL(string discName)
        {
            List<DocumentDetails> documentList = null;
            DbParameter p1 = DBHelper.CreateParameter("@discName", discName);
            commandObj = DBHelper.CreateCommand("select top 10 * from Document_Details d1,Disciplines d2 where d1.Discipline_ID=d2.Discipline_ID and d2.Discipline_Name=@discName order by d1.Upload_Date", CommandType.Text,p1);
            try
            {
                DataTable table = DBHelper.ExecuteReader(commandObj);
                if (table.Rows.Count > 0)
                {
                    documentList = new List<DocumentDetails>();
                    foreach (DataRow row in table.Rows)
                    {
                        documentList.Add(new DocumentDetails
                        {
                            DocumentID = Convert.ToInt32(row["Document_ID"]),
                            DocumentName = row["Document_Name"].ToString(),
                            Title = row["Title"].ToString(),
                            Author = row["Author"].ToString(),
                            DocumentTypeID = Convert.ToInt32(row["Document_Type_ID"]),
                            UploadDate = Convert.ToDateTime(row["Upload_Date"]),
                            DocumentPath = row["Document_Path"].ToString(),
                            DocumentDescription = row["Document_Description"].ToString(),
                            Price = Convert.ToDouble(row["Price"])

                        });
                    }
                }
            }
            catch (DbException ex)
            {
                throw ex;
            }
            catch (ELibraryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return documentList;
        }
        /// <summary>
        /// gets an id as extension to be appeneded to doc name for uniquesness in the folder
        /// </summary>
        /// <returns>extension for filename in the folder</returns>
        public int GetDocExtDAL()
        {
            int docExt = 0;
            commandObj = DBHelper.CreateCommand("select max(Document_ID) from Document_Details", CommandType.Text);
            try
            {
                DataTable table = DBHelper.ExecuteReader(commandObj);

                
                if(table.Rows[0][0]==DBNull.Value)
                    docExt = 0;
                else
                {
                    docExt = Convert.ToInt32(table.Rows[0][0]) + 1;
                }
            }
            catch (DbException ex)
            {
                throw ex;
            }
            catch (ELibraryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return docExt;

        }
        /// <summary>
        /// gets doc type
        /// </summary>
        /// <param name="typeID">document type id</param>
        /// <returns>document type name</returns>
        public string GetDocumentType(int typeID)
        {
            string type = null;
            DbParameter p1 = DBHelper.CreateParameter("@typeID", typeID);
            commandObj = DBHelper.CreateCommand("select Document_Type_Name from Document_Type_details where Document_Type_ID=@typeID", CommandType.Text, p1);
            try
            {
                var typeName = DBHelper.ExecuteScalar(commandObj);
                if (typeName != null)
                    type = typeName.ToString();

            }
            catch (DbException ex)
            {
                throw ex;
            }
            catch (ELibraryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return type;
        }
        /// <summary>
        /// gets discipline name
        /// </summary>
        /// <param name="typeID">discipline id</param>
        /// <returns>discipline name</returns>
        public string GetDisciplineName(int typeID)
        {
            string type = null;
            DbParameter p1 = DBHelper.CreateParameter("@typeID", typeID);
            commandObj = DBHelper.CreateCommand("select Discipline_Name from Disciplines where Discipline_ID=@typeID", CommandType.Text, p1);
            try
            {
                var typeName = DBHelper.ExecuteScalar(commandObj);
                if (typeName != null)
                    type = typeName.ToString();

            }
            catch (DbException ex)
            {
                throw ex;
            }
            catch (ELibraryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return type;
        }
        /// <summary>
        /// adds document to document_details table
        /// </summary>
        /// <param name="docObj">document object</param>
        /// <returns>true/false on success or failure</returns>
        public bool AddDocumentDetailsDAL(DocumentDetails docObj)
        {
            bool isAdded = false;
            DbParameter p1 = DBHelper.CreateParameter("@docName",docObj.DocumentName );
            DbParameter p2 = DBHelper.CreateParameter("@docDesc",docObj.DocumentDescription);
            DbParameter p3 = DBHelper.CreateParameter("@docPath",docObj.DocumentPath);
            DbParameter p4 = DBHelper.CreateParameter("@docTypeID",docObj.DocumentTypeID);
            DbParameter p5 = DBHelper.CreateParameter("@docDiscID", docObj.DisciplineID);
            DbParameter p6 = DBHelper.CreateParameter("@title", docObj.Title);
            DbParameter p7 = DBHelper.CreateParameter("@author",docObj.Author);
            DbParameter p8 = DBHelper.CreateParameter("@uploadDate", docObj.UploadDate);
            DbParameter p9 = DBHelper.CreateParameter("@price", docObj.Price);
         
           

            commandObj = DBHelper.CreateCommand("AddDocument", CommandType.StoredProcedure, p1, p2, p3, p4, p5, p6, p7, p8, p9);

            try
            {

                int rowsAffect = DBHelper.ExecuteNonQuery(commandObj);

                //Checking if successfully inserted
                if (rowsAffect > 0)
                    isAdded = true;
            }
            catch (DbException ex)
            {
                throw ex;
            }
            catch (ELibraryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isAdded;
        }
        /// <summary>
        /// update document in the document_details
        /// </summary>
        /// <param name="docObj">document object to be updated</param>
        /// <returns>true/false on success or failure</returns>
        public bool UpdateDocumentDAL(DocumentDetails docObj)
        {
            bool isUpdated = false;
            DbParameter p1 = DBHelper.CreateParameter("@docID", docObj.DocumentID);
            DbParameter p2 = DBHelper.CreateParameter("@docName", docObj.DocumentName);
            DbParameter p3 = DBHelper.CreateParameter("@docDesc", docObj.DocumentDescription);
            DbParameter p4 = DBHelper.CreateParameter("@docPath", docObj.DocumentPath);
            DbParameter p5 = DBHelper.CreateParameter("@docTypeID", docObj.DocumentTypeID);
            DbParameter p6 = DBHelper.CreateParameter("@docDiscID", docObj.DisciplineID);
            DbParameter p7 = DBHelper.CreateParameter("@title", docObj.Title);
            DbParameter p8 = DBHelper.CreateParameter("@author", docObj.Author);
            DbParameter p9 = DBHelper.CreateParameter("@price", docObj.Price);
            commandObj = DBHelper.CreateCommand("UpdateDocumentDetails", CommandType.StoredProcedure, p1, p2, p3, p4, p5, p6, p7, p8, p9);

            try
            {

                int rowsAffect = DBHelper.ExecuteNonQuery(commandObj);

                //Checking if successfully inserted
                if (rowsAffect > 0)
                    isUpdated = true;
            }
            catch (DbException ex)
            {
                throw ex;
            }
            catch (ELibraryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isUpdated;

        }
        /// <summary>
        /// check if document id exists
        /// </summary>
        /// <param name="documentDetailsObj">document object</param>
        /// <returns>true or false on success or false</returns>
        public bool ValidateDocumentIDDAL(DocumentDetails documentDetailsObj)
        {
            bool isValidDocumentID = false;
            DbParameter p1 = DBHelper.CreateParameter("@Document_ID", documentDetailsObj.DocumentID);
            commandObj = DBHelper.CreateCommand("select Document_ID from Document_Details where Document_ID=@Document_ID", CommandType.Text, p1);
            try
            {
                var docID = DBHelper.ExecuteScalar(commandObj);
                if (docID != null)
                    isValidDocumentID = true;
            }
            catch (DbException ex)
            {
                throw ex;
            }
            catch (ELibraryException ex)
            {
                throw ex;
            }
            return isValidDocumentID;
        }
        /// <summary>
        /// deletes document from document_details table
        /// </summary>
        /// <param name="documentDetailsObj">document object to be deleted</param>
        /// <returns>true or false on success or failure</returns>
        public bool DeleteDocumentDAL(DocumentDetails documentDetailsObj)
        {
            bool isDeleted = false;
            DbParameter p2 = DBHelper.CreateParameter("@Document_ID", documentDetailsObj.DocumentID);
            commandObj = DBHelper.CreateCommand("delete from Document_Details where Document_ID=@Document_ID", CommandType.Text, p2);
            try
            {
                int rowAffected = DBHelper.ExecuteNonQuery(commandObj);
                if (rowAffected>0)
                    isDeleted = true;
            }
            catch (DbException ex)
            {
                throw ex;
            }
            catch (ELibraryException ex)
            {
                throw ex;
            }
            return isDeleted;
        }
        /// <summary>
        /// returns all documents
        /// </summary>
        /// <returns>document list</returns>
        public List<DocumentDetails> ViewAllDocumentsDAL()
        {
            List<DocumentDetails> documentList =null ;


            commandObj = DBHelper.CreateCommand("DisplayAllDocuments", CommandType.StoredProcedure);



            try
            {
                DataTable table = DBHelper.ExecuteReader(commandObj);
                if (table.Rows.Count >0)
                {
                    documentList = new List<DocumentDetails>();
                    foreach (DataRow row in table.Rows)
                    {
                        documentList.Add(new DocumentDetails
                        {
                            DocumentID = Convert.ToInt32(row["Document_ID"]),
                            DocumentName = row["Document_Name"].ToString(),
                            Title = row["Title"].ToString(),
                            Author = row["Author"].ToString(),
                            UploadDate = Convert.ToDateTime(row["Upload_Date"]),
                            DocumentDescription = row["Document_Description"].ToString(),
                            Price = Convert.ToDouble(row["Price"])
                        });
                    }
                }
               
            }
            catch (DbException ex)
            {
                throw ex;
            }
            catch (ELibraryException ex)
            {
                ELibraryException exceptionObj = new ELibraryException("No documents Available", ex);
                throw exceptionObj;
            }
            return documentList;

        }
        /// <summary>
        /// returns documents by name
        /// </summary>
        /// <param name="name">document name</param>
        /// <returns>document list</returns>
        public List<DocumentDetails> ViewDocumentsByName(string name)
        {

            string docName = "%" + name + "%";

            DbParameter p1 = DBHelper.CreateParameter("@DocumentName", docName);


            commandObj = DBHelper.CreateCommand("DisplayDocumentsByName", CommandType.StoredProcedure, p1);

            List<DocumentDetails> documentList = null;

            try
            {
                DataTable table = DBHelper.ExecuteReader(commandObj);
                if(table.Rows.Count > 0)
                {
                    documentList = new List<DocumentDetails>();
                    foreach (DataRow row in table.Rows)
                    {
                        documentList.Add(new DocumentDetails
                        {
                            DocumentID = Convert.ToInt32(row["Document_ID"]),
                            DocumentName = row["Document_Name"].ToString(),
                            Title = row["Title"].ToString(),
                            Author = row["Author"].ToString(),
                            DocumentTypeID = Convert.ToInt32(row["Document_Type_ID"]),
                            DocumentPath = row["Document_Path"].ToString(),
                            UploadDate =Convert.ToDateTime( row["Upload_Date"]),
                            DocumentDescription = row["Document_Description"].ToString(),
                            Price = Convert.ToDouble(row["Price"])
                        });
                    }
                }

                return documentList;
            }
            catch (DbException ex)
            {
                throw ex;
            }
            catch (ELibraryException ex)
            {
                ELibraryException exceptionObj = new ELibraryException("No documents Available", ex);
                throw exceptionObj;
            }

        }

        /// <summary>
        /// returns documents by discipline
        /// </summary>
        /// <param name="discipline">discipline name</param>
        /// <returns>document list</returns>
        public List<DocumentDetails> ViewDocumentsByDiscipline(string discipline)
        {
           

            DbParameter p1 = DBHelper.CreateParameter("@DisciplineName", discipline);


            commandObj = DBHelper.CreateCommand("DisplayDocumentsByDiscipline", CommandType.StoredProcedure, p1);

            List<DocumentDetails> documentList = null; 

            try
            {
                DataTable table = DBHelper.ExecuteReader(commandObj);
                if (table.Rows.Count > 0)
                {

                    documentList= new List<DocumentDetails>();
                    foreach (DataRow row in table.Rows)
                    {
                        documentList.Add(new DocumentDetails
                        {
                            DocumentID = Convert.ToInt32(row["Document_ID"]),
                            DocumentName = row["Document_Name"].ToString(),
                            Title = row["Title"].ToString(),
                            Author = row["Author"].ToString(),
                            DocumentTypeID = Convert.ToInt32(row["Document_Type_ID"]),
                            UploadDate = Convert.ToDateTime(row["Upload_Date"]),
                            DocumentPath = row["Document_Path"].ToString(),
                            DocumentDescription = row["Document_Description"].ToString(),
                            Price = Convert.ToDouble(row["Price"])
                        });
                    }
                }
                return documentList;
            }
            catch (DbException ex)
            {
                throw ex;
            }
            catch (ELibraryException ex)
            {
                ELibraryException exceptionObj = new ELibraryException("No documents Available", ex);
                throw exceptionObj;
            }

        }
        /// <summary>
        /// returns documents by type(freebie,premium)
        /// </summary>
        /// <param name="type">document type name</param>
        /// <returns>document list</returns>
        public List<DocumentDetails> AccessDocumentByTypeDAL(string type)
        {


            DbParameter p1 = DBHelper.CreateParameter("@DocumentType", type);


            commandObj = DBHelper.CreateCommand("DisplayDocumentsByType", CommandType.StoredProcedure, p1);

            List<DocumentDetails> documentList = null;

            try
            {
                DataTable table = DBHelper.ExecuteReader(commandObj);
                if (table.Rows.Count > 0)
                {

                    documentList = new List<DocumentDetails>();
                    foreach (DataRow row in table.Rows)
                    {
                        documentList.Add(new DocumentDetails
                        {
                            DocumentID = Convert.ToInt32(row["Document_ID"]),
                            DocumentName = row["Document_Name"].ToString(),
                            DocumentPath=row["Document_Path"].ToString(),
                            Title = row["Title"].ToString(),
                            DocumentTypeID=Convert.ToInt32( row["Document_Type_ID"]),
                            Author = row["Author"].ToString(),
                            UploadDate = Convert.ToDateTime(row["Upload_Date"]),
                            DocumentDescription = row["Document_Description"].ToString(),
                            Price = Convert.ToDouble(row["Price"])
                        });
                    }
                }
                return documentList;
            }
            catch (DbException ex)
            {
                throw ex;
            }
            catch (ELibraryException ex)
            {
                ELibraryException exceptionObj = new ELibraryException("No documents Available", ex);
                throw exceptionObj;
            }

        }
        /// <summary>
        /// returns all disciplines
        /// </summary>
        /// <returns>document list</returns>
        public List<Disciplines> GetAllDisciplinesDAL()
        {
            List<Disciplines> disciplineList=null;
            commandObj = DBHelper.CreateCommand("select * from disciplines", CommandType.Text);
            try
            {
                DataTable table = DBHelper.ExecuteReader(commandObj);
                if (table.Rows.Count > 0)
                {

                    disciplineList = new List<Disciplines>();
                    foreach (DataRow row in table.Rows)
                    {
                        disciplineList.Add(new Disciplines
                        {
                            DisciplineID = Convert.ToInt32(row["discipline_id"]),
                            DisciplineName = Convert.ToString(row["discipline_name"])
                        });
                    }
                }
            }
            catch (DbException ex)
            {
                throw ex;
            }
            return disciplineList;
        }
        /// <summary>
        /// returns all document ids
        /// </summary>
        /// <returns>document id list</returns>
        public List<int> GetAllDocumentIDDAL()
        {
            List<int> docIdList = null;
            commandObj = DBHelper.CreateCommand("select document_id from document_details", CommandType.Text);
            try
            {
                DataTable table = DBHelper.ExecuteReader(commandObj);
                if (table.Rows.Count > 0)
                {

                    docIdList = new List<int>();
                    foreach (DataRow row in table.Rows)
                    {
                        docIdList.Add(Convert.ToInt32( row["document_id"]));
                    }
                }
            }
            catch (DbException ex)
            {
                throw ex;
            }
            return docIdList;
        }
        /// <summary>
        /// searches document by id and returns it
        /// </summary>
        /// <param name="docId">document id</param>
        /// <returns>document object</returns>
        public DocumentDetails GetDocumentByID(int docId)
        {
            DocumentDetails docObj = null;

            DbParameter p1 = DBHelper.CreateParameter("@docId", docId);
            commandObj = DBHelper.CreateCommand("select * from Document_Details where Document_ID=@docId", CommandType.Text, p1);
            try

            {
                DataTable table = DBHelper.ExecuteReader(commandObj);

                if (table.Rows.Count == 1)
                {
                    docObj = new DocumentDetails();
                    docObj.DocumentID = Convert.ToInt32(table.Rows[0][0]);
                    docObj.DocumentName = Convert.ToString(table.Rows[0][1]);
                    docObj.DocumentDescription = Convert.ToString(table.Rows[0][2]);
                    docObj.DocumentPath = Convert.ToString(table.Rows[0][3]);
                    docObj.DocumentTypeID = Convert.ToInt32(table.Rows[0][4]);
                    docObj.DisciplineID = Convert.ToInt32(table.Rows[0][5]);
                    docObj.Title = Convert.ToString(table.Rows[0][6]);
                    docObj.Author = Convert.ToString(table.Rows[0][7]);
                    docObj.Price = Convert.ToDouble(table.Rows[0][9]);
                    docObj.UploadDate = Convert.ToDateTime(table.Rows[0][8]);
                   

                }
                
                return docObj;
            }
            catch (DbException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// returns all document type
        /// </summary>
        /// <returns>document type list</returns>
        public List<DocumentTypeDetails> GetAllDocumentTypesDAL()
        {
            List<DocumentTypeDetails> documentTypeList = null;
            commandObj = DBHelper.CreateCommand("select * from document_type_details", CommandType.Text);
            try
            {
                DataTable table = DBHelper.ExecuteReader(commandObj);
                if (table.Rows.Count > 0)
                {

                    documentTypeList = new List<DocumentTypeDetails>();
                    foreach (DataRow row in table.Rows)
                    {
                        documentTypeList.Add(new DocumentTypeDetails
                        {
                            DocumentTypeID = Convert.ToInt32(row["document_type_id"]),
                            DocumentTypeName = Convert.ToString(row["document_type_name"])
                        });
                    }
                }
            }
            catch (DbException ex)
            {
                throw ex;
            }
            return documentTypeList;
        }


        /// <summary>
        /// get document type id from name
        /// </summary>
        /// <param name="typeName">document type name</param>
        /// <returns>document id</returns>
        public int GetDocumentTypeID(string typeName)
        {
            
            int type = 0;
            DbParameter p1 = DBHelper.CreateParameter("@typeName", typeName);
            commandObj = DBHelper.CreateCommand("select Document_Type_ID from Document_Type_details where Document_Type_Name=@typeName", CommandType.Text, p1);
            try
            {
                var typeId = DBHelper.ExecuteScalar(commandObj);
                if (typeId != null)
                    type =Convert.ToInt32( typeId);

            }
            catch (DbException ex)
            {
                throw ex;
            }
            catch (ELibraryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return type;
        }

        /// <summary>
        /// get discipline id from name
        /// </summary>
        /// <param name="discName">discipline name</param>
        /// <returns>discipline id</returns>
        public int GetDisciplineID(string discName)
        {

            int disc = 0;
            DbParameter p1 = DBHelper.CreateParameter("@discName", discName);
            commandObj = DBHelper.CreateCommand("select Discipline_ID from Disciplines where Discipline_Name=@discName", CommandType.Text, p1);
            try
            {
                var discId = DBHelper.ExecuteScalar(commandObj);
                if (discId != null)
                    disc = Convert.ToInt32(discId);

            }
            catch (DbException ex)
            {
                throw ex;
            }
            catch (ELibraryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return disc;
        }
        /// <summary>
        /// get documents bought by an user
        /// </summary>
        /// <param name="userID">user id</param>
        /// <returns>document id list</returns>
        public List<int> GetDocumentsBoughtDAL(string userID)
        {
            List<int> docList = null;
            DbParameter p1 = DBHelper.CreateParameter("@userID", userID);
            commandObj = DBHelper.CreateCommand("select documentid from PurchasedDetails where user_id=@userID", CommandType.Text,p1);
            try
            {
                DataTable table = DBHelper.ExecuteReader(commandObj);
                if (table.Rows.Count > 0)
                {

                    docList = new List<int>();
                    foreach (DataRow row in table.Rows)
                    {
                        docList.Add(Convert.ToInt32(row["documentid"]));
                    }
                }
            }
            catch (DbException ex)
            {
                throw ex;
            }
            return docList;

        }


    }
}

