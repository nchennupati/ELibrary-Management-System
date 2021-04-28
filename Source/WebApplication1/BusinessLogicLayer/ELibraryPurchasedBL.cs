using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using ExceptionLayer;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    /// <summary>
    /// class containing purchase business logic
    /// </summary>
    public class ELibraryPurchasedBL
    {
      /// <summary>
      /// method to add a purchase
      /// </summary>
      /// <param name="detailsobj">purchase details object</param>
      /// <returns>true/false</returns>
       
        public bool PurchaseDocumentBL(PurchasedDetails detailsobj)
        {
            bool isAdded = false;
            ELibraryPurchasedDAL pruchaseDALObj = new ELibraryPurchasedDAL();
            try
            {
                isAdded = pruchaseDALObj.PurchaseDocumentDAL(detailsobj);
            }
            catch(ELibraryException ex)
            {
                throw ex;
            }
            return isAdded;
        }
        /// <summary>
        /// get purchase count
        /// </summary>
        /// <returns>count</returns>
        public int GetPurchasedCountBL()
        {
            ELibraryPurchasedDAL purchaseDAL = new ELibraryPurchasedDAL();
            try
            {
                int count = purchaseDAL.GetPurchasedCountDAL();
                return count;
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





    }
}

