using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using EntityLayer;
using ExceptionLayer;
using System.Text.RegularExpressions;
using System.IO;
namespace BusinessLogicLayer
{
    
    /// <summary>
    /// Class containing Document business logics
    /// </summary>
    public class ELibraryDocumentBL
    {
        /// <summary>
        /// Method to fetch recently added documents in the given discipline name
        /// Makes call to data access layer method
        /// </summary>
        /// <param name="discName">discipline name</param>
        /// <returns></returns>
        #region Method to fetch Recent documents
        public List<DocumentDetails> GetRecentDocumentByDisciplineBL(string discName)
        {
            List<DocumentDetails> documentList = null;
            ELibraryDocumentDAL eLibDALObj = new ELibraryDocumentDAL();
            try
            {
                documentList = eLibDALObj.GetRecentDocumentsByDisciplineDAL(discName);
            }
            catch (ELibraryException ex)
            {
                throw ex;
            }
            return documentList;
        }
        #endregion


        /// <summary>
        /// method to add document. makes call to data access layer method AddDocumentDetailsDAL
        /// </summary>
        /// <param name="docObj">Document details object</param>
        /// <returns>true/false</returns>
        public bool AddNewDocumentBL(DocumentDetails docObj)
        {
            bool isAdded = false;
            ELibraryDocumentDAL eLibDALObj = new ELibraryDocumentDAL();

            if(ValidateDocumentDetailsBL(docObj))
            {
               
                    if (eLibDALObj.AddDocumentDetailsDAL(docObj))
                        isAdded = true;
                
                  
            }

            return isAdded;
        }
        /// <summary>
        ///  method to update document. makes call to data access layer method UpdateDocumentDAL
        /// </summary>
        /// <param name="docObj">Document details object</param>
        /// <returns>true/false</returns>
        public bool UpdateDocumentBL(DocumentDetails docObj)
        {
            bool isUpdated = false;
            ELibraryDocumentDAL eLibDALObj = new ELibraryDocumentDAL();

            if (ValidateDocumentDetailsBL(docObj))
            {
                if (MoveDocumentBL(docObj))
                {
                    if (eLibDALObj.UpdateDocumentDAL(docObj))
                        isUpdated = true;
                }

            }

            return isUpdated;
        }
        /// <summary>
        /// method to move the document to the path ~/ELibInc/ELibDocuments and 
        /// correspoding folder Freebie or Premium
        /// </summary>
        /// <param name="docObj">Document details object</param>
        /// <returns>true/false</returns>
        private bool MoveDocumentBL(DocumentDetails docObj)
        {
            bool isMoved = false;
            ELibraryDocumentDAL eLibDALObj = new ELibraryDocumentDAL();

            //string currentFolder = Directory.GetCurrentDirectory();
            //string targetFolder = Directory.GetParent(currentFolder).ToString();
            //targetFolder = Directory.GetParent(targetFolder).ToString();
            //targetFolder = Directory.GetParent(targetFolder).ToString();

            string targetFolder = @"C:";
            targetFolder =targetFolder+@"\ELibDocuments";
           
            string docTypeName = eLibDALObj.GetDocumentType(docObj.DocumentTypeID);
            string targetSubFolder = targetFolder + @"\" + docTypeName;

            int docNameExt = eLibDALObj.GetDocExtDAL();

            
            string sourceFilePath = docObj.DocumentPath;
            string targetFilePath= targetSubFolder + @"\" + docObj.DocumentName + "_" + docNameExt.ToString() + ".pdf";
            

            try
            {
                if (!Directory.Exists(targetFolder))
                {
                    Directory.CreateDirectory(targetFolder);
                }


                if (!Directory.Exists(targetSubFolder))
                {
                    Directory.CreateDirectory(targetSubFolder);
                }

               File.Copy(sourceFilePath, targetFilePath, true);
                isMoved = true;
                docObj.DocumentPath = targetFilePath;
            }
            catch(IOException ex)
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



          
            return isMoved;
        }
        /// <summary>
        /// method to validate the document details
        /// </summary>
        /// <param name="docObj">Document details object</param>
        /// <returns>true/false</returns>
        private bool ValidateDocumentDetailsBL(DocumentDetails docObj)
        {
            bool isValid = true;
            StringBuilder message = new StringBuilder();
            if (docObj.DocumentName=="")
            {
                isValid = false;
                message.Append(Environment.NewLine + "DocumentName required");
            }
            if(docObj.DocumentDescription=="")
            {
                isValid = false;
                message.Append(Environment.NewLine + "Document Description required");
            }
            if(docObj.DocumentPath=="")
            {
                isValid = false;
                message.Append(Environment.NewLine + "Document Path required");
            }
            if(docObj.DocumentTypeID==0)
            {
                isValid = false;
                message.Append(Environment.NewLine + "Document Type required");
            }
            if(docObj.DisciplineID==0)
            {
                isValid = false;
                message.Append(Environment.NewLine + "Document Discipline required");
            }
            if(docObj.Price<=0)
            {
                isValid = false;
                message.Append(Environment.NewLine + "Document Price Cannot be 0 or negative");
            }
            if(docObj.Title=="")
            {
                isValid = false;
                message.Append(Environment.NewLine + "Document Title required");
            }
            if(docObj.Author=="")
            {
                isValid = false;
                message.Append(Environment.NewLine + "Document Author required");
            }
            if(docObj.UploadDate!=DateTime.Today)
            {
                isValid = false;
                message.Append(Environment.NewLine + "Document Upload Date required");
            }
            if(!Regex.IsMatch(docObj.DocumentPath,".*.pdf$"))
            {
                {
                    isValid = false;
                    message.Append(Environment.NewLine + "Document must be pdf");
                }
            }
            if (isValid == false)
                throw new ELibraryException(message.ToString());
            return isValid;
        }
        /// <summary>
        /// method to check whether the docID exists
        /// </summary>
        /// <param name="docObj">Document details object</param>
        /// <returns>true/false</returns>
        private bool ValidateDocumentIDBL(DocumentDetails docObj)
        {
            bool isValid = false;
            ELibraryDocumentDAL eLibDALObj = new ELibraryDocumentDAL();
            try
            {
                isValid = eLibDALObj.ValidateDocumentIDDAL(docObj);
            }
            catch (ELibraryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isValid;
        }
        /// <summary>
        /// method to delete makes call to the DAL  DeleteDocumentDAL
        /// </summary>
        /// <param name="docObj">Document details object</param>
        /// <returns>true/false</returns>
        public bool DeleteDocumentBL(DocumentDetails docObj)
        {
            bool isDeleted = false;
            ELibraryDocumentDAL eLibDALObj = new ELibraryDocumentDAL();
            try
            {
                if (ValidateDocumentIDBL(docObj))
                    isDeleted = eLibDALObj.DeleteDocumentDAL(docObj);
            }
            catch (ELibraryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isDeleted;
        }
        /// <summary>
        /// method to get all the documents makes call to the DAL ViewAllDocumentsDAL
        /// </summary>
        /// <returns>document list</returns>
        public List<DocumentDetails> ViewAllDocumentsBL()
        {
            ELibraryDocumentDAL eLibDALObj = new ELibraryDocumentDAL();
            try
            {
                var DocumentList = eLibDALObj.ViewAllDocumentsDAL();
                return DocumentList;
            }
            catch (ELibraryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="docName"></param>
        /// <returns></returns>
        public bool IsValid(string docName)
        {
            bool isValid = true;
            StringBuilder stringBuilderObj = new StringBuilder();
            if (docName == "")

            {
                stringBuilderObj.AppendLine("Document Name cant be empty");
                isValid = false;
            }
            if (isValid == false)
            {
                ELibraryException exceptionObj = new ELibraryException(stringBuilderObj.ToString());
                throw exceptionObj;
            }

            return isValid;
        }
        /// <summary>
        /// method to get document by name using DAL ViewDocumentsByName
        /// </summary>
        /// <param name="docName">Document Name</param>
        /// <returns>Document List</returns>
        public List<DocumentDetails> ViewDocumentsByNameBL(string docName)
        {
            ELibraryDocumentDAL eLibDALObj = new ELibraryDocumentDAL();
            List<DocumentDetails> documentList = null;
            try
            {
                if (IsValid(docName))
                {
                    documentList = eLibDALObj.ViewDocumentsByName(docName);
                }
                
            }
            catch (ELibraryException ex)
            {
                throw ex;
            }
            return documentList;
        }
        /// <summary>
        /// method to get document by discipline using DAL ViewDocumentsByDiscipline
        /// </summary>
        /// <param name="discipline">discipline</param>
        /// <returns>Document List</returns>
        public List<DocumentDetails> ViewDocumentsByDisciplineBL(string discipline)
        {
            ELibraryDocumentDAL eLibDALObj = new ELibraryDocumentDAL();
            try
            {
                var DocumentList = eLibDALObj.ViewDocumentsByDiscipline(discipline);
                return DocumentList;
            }
            catch (ELibraryException ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// method to get document by Type(freebie or premium) using DAL AccessDocumentByTypeDAL
        /// </summary>
        /// <param name="type">Type Name</param>
        /// <returns>Document List</returns>
        public List<DocumentDetails> AccessDocumentsByTypeBL(string type)
        {
            ELibraryDocumentDAL eLibDALObj = new ELibraryDocumentDAL();
            try
            {
                var DocumentList = eLibDALObj.AccessDocumentByTypeDAL(type);
                return DocumentList;
            }
            catch (ELibraryException ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// method to get all disciplines  using DAL GetAllDisciplinesDAL
        /// </summary>
        ///
        /// <returns>Discipline List</returns>
        public List<Disciplines> GetAllDisciplinesBL()
        {
            List<Disciplines> disciplineList = null;
            ELibraryDocumentDAL eLibDALObj = new ELibraryDocumentDAL();
            try
            {
                disciplineList = eLibDALObj.GetAllDisciplinesDAL();
            }
            catch (ELibraryException ex)
            {
                throw ex;
            }
            return disciplineList;
        }

        /// <summary>
        /// method to get all document types makes call to DAL method GetAllDocumentTypesDAL
        /// </summary>
        /// <returns>document list</returns>
        public List<DocumentTypeDetails> GetAllDocumentTypesBL()
        {
            List<DocumentTypeDetails> documentTypeList = null;
            ELibraryDocumentDAL eLibDALObj = new ELibraryDocumentDAL();
            try
            {
                documentTypeList = eLibDALObj.GetAllDocumentTypesDAL();
            }
            catch (ELibraryException ex)
            {
                throw ex;
            }
            return documentTypeList;
        }
        /// <summary>
        /// method to get all documentid makes call to DAL method GetAllDocumentIDDAL
        /// </summary>
        /// <returns>document id list</returns>
        public List<int> GetAllDocumentIDBL()
        {
            List<int> documentIDList = null;
            ELibraryDocumentDAL eLibDALObj = new ELibraryDocumentDAL();
            try
            {
                documentIDList = eLibDALObj.GetAllDocumentIDDAL();
            }
            catch (ELibraryException ex)
            {
                throw ex;
            }
            return documentIDList;
        }
        /// <summary>
        /// Get document by ID makes call to DAL method GetDocumentByID
        /// </summary>
        /// <param name="docId">document id</param>
        /// <returns>document object</returns>
        public DocumentDetails GetDocumentByID(int docId)
        {
            DocumentDetails docObj = null;
            ELibraryDocumentDAL eLibDALObj = new ELibraryDocumentDAL();
            try
            {
                docObj = eLibDALObj.GetDocumentByID(docId);
            }
            catch (ELibraryException ex)
            {
                throw ex;
            }
            return docObj;
        }

        /// <summary>
        /// gets type name of a document
        /// </summary>
        /// <param name="typeID">type id</param>
        /// <returns>document type name</returns>
        public string GetDocumentTypeBL(int typeID)
        {
            string typeName = null;
            ELibraryDocumentDAL eLibDALObj = new ELibraryDocumentDAL();
            try
            {
                typeName = eLibDALObj.GetDocumentType(typeID);
            }
            catch (ELibraryException ex)
            {
                throw ex;
            }
            return typeName;
        }
        /// <summary>
        /// gets discipline name
        /// </summary>
        /// <param name="typeID">type id</param>
        /// <returns>discipline name</returns>
        public string GetDisciplineNameBL(int typeID)
        {
            string typeName = null;
            ELibraryDocumentDAL eLibDALObj = new ELibraryDocumentDAL();
            try
            {
                typeName = eLibDALObj.GetDisciplineName(typeID);
            }
            catch (ELibraryException ex)
            {
                throw ex;
            }
            return typeName;
        }
        /// <summary>
        /// gets document id
        /// </summary>
        /// <param name="typeName">type name</param>
        /// <returns>id</returns>
        public int GetDocumentTypeIDBL(string typeName)
        {
            int typeID = 0;
            ELibraryDocumentDAL eLibDALObj = new ELibraryDocumentDAL();
            try
            {
                typeID = eLibDALObj.GetDocumentTypeID(typeName);
            }
            catch (ELibraryException ex)
            {
                throw ex;
            }
            return typeID;
        }
        /// <summary>
        /// gets discipline id 
        /// </summary>
        /// <param name="discName">discipline name</param>
        /// <returns>id</returns>
        public int GetDisciplineIDBL(string discName)
        {
            int typeID = 0;
            ELibraryDocumentDAL eLibDALObj = new ELibraryDocumentDAL();
            try
            {
                typeID = eLibDALObj.GetDisciplineID(discName);
            }
            catch (ELibraryException ex)
            {
                throw ex;
            }
            return typeID;
        }
        /// <summary>
        /// gets documents bought by a user
        /// </summary>
        /// <param name="userID">user id</param>
        /// <returns>document id list</returns>
        public List<int> GetDocumentsBoughtBL(string userID)
        {
            List<int> documentIDList = null;
            ELibraryDocumentDAL eLibDALObj = new ELibraryDocumentDAL();
            try
            {
                documentIDList = eLibDALObj.GetDocumentsBoughtDAL(userID);
            }
            catch (ELibraryException ex)
            {
                throw ex;
            }
            return documentIDList;
        }
    }
}
