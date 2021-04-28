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
    public class ELibraryUserDAL
    {
        DbCommand commandObj;

        public bool VerifyUserIDDAL(string userID)
        {
            bool isValidUserID = false;
            DbParameter p1 = DBHelper.CreateParameter("@userID", userID);
            commandObj = DBHelper.CreateCommand("select User_ID from User_Details where User_ID=@userID", CommandType.Text,p1);
            try
            {
               var uID = DBHelper.ExecuteScalar(commandObj);

                if (uID == null)
                    isValidUserID = true;

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
            
            return isValidUserID;
        }
        public bool RegisterDAL(UserDetails userObj)
        {
            bool isAdded = false;

            DbParameter p1 = DBHelper.CreateParameter("@userID", userObj.UserID);
            DbParameter p2 = DBHelper.CreateParameter("@firstName", userObj.FirstName);
            DbParameter p3 = DBHelper.CreateParameter("@lastName", userObj.LastName);
            DbParameter p4 = DBHelper.CreateParameter("@dateOfBirth", userObj.DateOfBirth);
            DbParameter p5 = DBHelper.CreateParameter("@userAddress", userObj.UserAddress);
            DbParameter p6 = DBHelper.CreateParameter("@landLineNumber", userObj.LandLineNumber);
            DbParameter p7 = DBHelper.CreateParameter("@areaOfInterest", userObj.AreaOfInterest);
            DbParameter p8 = DBHelper.CreateParameter("@mobileNumber", userObj.MobileNumber);
            DbParameter p9 = DBHelper.CreateParameter("@gender", userObj.Gender);
            DbParameter p10 = DBHelper.CreateParameter("@userType", "non subscriber");
            DbParameter p11 = DBHelper.CreateParameter("@dateOfRegistration", userObj.DateOfBirth);
            DbParameter p12 = DBHelper.CreateParameter("@password", userObj.Pasword);

            commandObj = DBHelper.CreateCommand("AddUserDetails", CommandType.StoredProcedure, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12);

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

    }
}
