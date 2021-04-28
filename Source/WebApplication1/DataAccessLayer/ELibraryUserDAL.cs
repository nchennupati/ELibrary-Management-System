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
    /// data access layer for users
    /// </summary>
    public class ELibraryUserDAL
    {
        DbCommand commandObj;
        /// <summary>
        /// verify user id by checking if user id already exists or not
        /// </summary>
        /// <param name="userID">user id to be searched for</param>
        /// <returns>true/false on existence or not</returns>
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
        /// <summary>
        /// register the user. add user to the user_details table
        /// </summary>
        /// <param name="userObj">User object containing details to be added</param>
        /// <returns>true/false on successful insertion or not</returns>
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
            DbParameter p10 = DBHelper.CreateParameter("@userType", "Non subscriber");
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
        /// <summary>
        /// validate user login to check if valid user id and password
        /// </summary>
        /// <param name="userID">user id</param>
        /// <param name="password">password</param>
        /// <returns>user object or null on success or failure</returns>
        public UserDetails UserLoginDAL(string userID, string password)
        {

            DbParameter p1 = DBHelper.CreateParameter("@userID", userID);
            DbParameter p2 = DBHelper.CreateParameter("@password", password);

            UserDetails userDetailsObj = null;

            commandObj = DBHelper.CreateCommand("select * from User_Details where User_ID=@userID and Pasword=@password", CommandType.Text, p1, p2);
            try

            {
                DataTable table = DBHelper.ExecuteReader(commandObj);

                if (table.Rows.Count == 1)
                {
                    userDetailsObj = new UserDetails();
                    userDetailsObj.UserID = Convert.ToString(table.Rows[0][0]);
                    userDetailsObj.FirstName = Convert.ToString(table.Rows[0][1]);
                    userDetailsObj.LastName = Convert.ToString(table.Rows[0][2]);
                    userDetailsObj.DateOfBirth = Convert.ToDateTime(table.Rows[0][3]);
                    userDetailsObj.UserAddress = Convert.ToString(table.Rows[0][4]);
                    userDetailsObj.LandLineNumber = Convert.ToString(table.Rows[0][5]);
                    userDetailsObj.AreaOfInterest = Convert.ToString(table.Rows[0][6]);
                    userDetailsObj.MobileNumber = Convert.ToString(table.Rows[0][7]);
                    userDetailsObj.Gender = Convert.ToString(table.Rows[0][8]);
                    userDetailsObj.UserType = Convert.ToString(table.Rows[0][9]);
                    userDetailsObj.DateOfRegistration = Convert.ToDateTime(table.Rows[0][10]);
                    userDetailsObj.Pasword = Convert.ToString(table.Rows[0][11]);

                }

                return userDetailsObj;

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
        }
        /// <summary>
        /// update non subscriber to subscriber
        /// </summary>
        /// <param name="userObj">user to be subscribed</param>
        /// <returns>true or false on success or failure</returns>
        public bool UpdateSubscriptionDAL(UserDetails userObj)
        {
            bool isUpdated = false;

            DbParameter p1 = DBHelper.CreateParameter("@userID", userObj.UserID);
            commandObj = DBHelper.CreateCommand("SubscribeUser", CommandType.StoredProcedure, p1);

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
        /// get count of registered users
        /// </summary>
        /// <returns>count</returns>
        public int GetRegisteredUserCountDAL()
        {
            int count = 0;
            commandObj = DBHelper.CreateCommand("select count(*) from User_Details", CommandType.Text);
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
        /// <summary>
        /// get count subscribed users
        /// </summary>
        /// <returns>count</returns>
        public int GetSubscribedUserCountDAL()
        {
            int count = 0;
            commandObj = DBHelper.CreateCommand("select count(*) from User_Details where User_Type='Subscriber'", CommandType.Text);
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

        public bool UpdateDetailsUserDAL(UserDetails userUpdateObj)
        {

            bool isUpdated = false;
            DbParameter p1 = DBHelper.CreateParameter("@userId", userUpdateObj.UserID);
            DbParameter p2 = DBHelper.CreateParameter("@firstName", userUpdateObj.FirstName);
            DbParameter p3 = DBHelper.CreateParameter("@lastName", userUpdateObj.LastName);
            DbParameter p4 = DBHelper.CreateParameter("@userAddress", userUpdateObj.UserAddress);
            DbParameter p5 = DBHelper.CreateParameter("@landLineNumber", userUpdateObj.LandLineNumber);
            DbParameter p6 = DBHelper.CreateParameter("@areaOfInterest", userUpdateObj.AreaOfInterest);
            DbParameter p7 = DBHelper.CreateParameter("@mobileNumber", userUpdateObj.MobileNumber);
            DbParameter p8 = DBHelper.CreateParameter("@pasword", userUpdateObj.Pasword);

            commandObj = DBHelper.CreateCommand("UpdateUserDetails", CommandType.StoredProcedure, p1, p2, p3, p4, p5, p6, p7, p8);

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
    }
}
