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
    /// data access layer for purchase
    /// </summary>
    public class ELibraryPurchasedDAL
    {
        DbCommand commandObj;
        /// <summary>
        /// add purchase details to the purchaseddetails table
        /// </summary>
        /// <param name="detailsobj">purchase object</param>
        /// <returns>true or false on success or failure</returns>
        public bool PurchaseDocumentDAL(PurchasedDetails detailsobj)
        {
           
            DbParameter p2 = DBHelper.CreateParameter("@userID", detailsobj.UserID);
            DbParameter p1 = DBHelper.CreateParameter("@docID", detailsobj.DocumentID);
            DbParameter p3 = DBHelper.CreateParameter("@purchaseDate", detailsobj.PurchasedDate);
          
            commandObj = DBHelper.CreateCommand("AddPurchaseDetails", CommandType.StoredProcedure, p1, p2, p3);
            try
            {

                int rowsAffect = DBHelper.ExecuteNonQuery(commandObj);
                return rowsAffect > 0 ? true : false;
            }
            catch (DbException ex)
            {
                ELibraryException exceptionObj = new ELibraryException("Unable to Purchase Document", ex);
                throw exceptionObj;
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
        /// get count of purchases
        /// </summary>
        /// <returns>count</returns>
        public int GetPurchasedCountDAL()
        {
            int count = 0;
            commandObj = DBHelper.CreateCommand("select count(*) from PurchasedDetails", CommandType.Text);
            try
            {
                DataTable table = DBHelper.ExecuteReader(commandObj);


                if (table.Rows[0][0] == DBNull.Value)
                    count = 0;
                else
                {
                    count = Convert.ToInt32(table.Rows[0][0]);
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
            return count;
        }
    }
}
