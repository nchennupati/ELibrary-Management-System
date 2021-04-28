using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using EntityLayer;
using ExceptionLayer;
using System.Text.RegularExpressions;
namespace BusinessLogicLayer
{
    /// <summary>
    /// user business logic layer
    /// </summary>
    public class ELibraryUserBL
    {
        /// <summary>
        /// register user
        /// </summary>
        /// <param name="userObj">user object</param>
        /// <returns>true or false on success or failure</returns>
        public bool RegisterBL(UserDetails userObj)
        {
            bool isAdded = false;
            try
            {
                ELibraryUserDAL eLibDAL = new ELibraryUserDAL();
                if (ValidateUserBL(userObj))
                {
                    bool isValidUserID = eLibDAL.VerifyUserIDDAL(userObj.UserID);
                    if (!isValidUserID)
                        throw new ELibraryException("User ID already exists");

                    isAdded = eLibDAL.RegisterDAL(userObj);
                }
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
        /// validates user
        /// </summary>
        /// <param name="userObj">user details</param>
        /// <returns>true/false</returns>
        private bool ValidateUserBL(UserDetails userObj)
        {
            bool isValid = true;
            StringBuilder message = new StringBuilder();
            if (userObj.UserID == "")
            {
                isValid = false;
                message.Append(Environment.NewLine + "UserID Required");
            }
            if (userObj.FirstName == "")
            {
                isValid = false;
                message.Append(Environment.NewLine + "First Name Required");
            }
            if (userObj.LastName == "")
            {
                isValid = false;
                message.Append(Environment.NewLine + "Last Name Required");
            }
            if (userObj.DateOfBirth == null)
            {
                isValid = false;
                message.Append(Environment.NewLine + "Date of Birth Required");
            }
            if (userObj.UserAddress == "")
            {
                isValid = false;
                message.Append(Environment.NewLine + "Address Required");

            }
            if (userObj.LandLineNumber == "")
            {
                isValid = false;
                message.Append(Environment.NewLine + "Landline number Required");

            }
            if (userObj.MobileNumber == "")
            {
                isValid = false;
                message.Append(Environment.NewLine + "Mobile number Required");

            }
            if (userObj.AreaOfInterest == "")
            {
                isValid = false;
                message.Append(Environment.NewLine + "Areas of interest Required");

            }
            if (userObj.Gender == "")
            {
                isValid = false;
                message.Append(Environment.NewLine + "Gender Required");

            }
            if (userObj.Pasword == "")
            {
                isValid = false;
                message.Append(Environment.NewLine + "Password Required");

            }
            if(userObj.AreaOfInterest=="")
            {
                isValid = false;
                message.Append(Environment.NewLine + "Area of Interest Required");

            }
            if (userObj.UserID.Length < 8 || userObj.UserID.Length > 15)
            {
                isValid = false;
                message.Append(Environment.NewLine + "User ID must be between 8 and 15 characters long");
            }
            if (!Regex.IsMatch(userObj.FirstName, "[A-Za-z ]{1,50}"))
            {
                isValid = false;
                message.Append(Environment.NewLine + "First Name must contain only characters");
            }
            if (!Regex.IsMatch(userObj.LastName, "[A-Za-z ]{1,50}"))
            {
                isValid = false;
                message.Append(Environment.NewLine + "Last Name must contain only characters");
            }
            if (GetAge(userObj.DateOfBirth) < 18)
            {
                isValid = false;
                message.Append(Environment.NewLine + "Minimum age must be 18 years");
            }
            if (!Regex.IsMatch(userObj.LandLineNumber, "[0-9]{3}-[0-9]{4}-[0-9]{4}"))
            {
                isValid = false;
                message.Append(Environment.NewLine + "Landline must be of the format xxx-xxxx-xxxx");
            }
            if (!Regex.IsMatch(userObj.MobileNumber, "[0-9]{3}-[0-9]{4}-[0-9]{4}"))
            {
                isValid = false;
                message.Append(Environment.NewLine + "Mobile number must be of the format xxx-xxxx-xxxx");
            }
            if (!(userObj.Gender.CompareTo("F") == 0 || userObj.Gender.CompareTo("M")==0))
            {
                isValid = false;
                message.Append(Environment.NewLine + "Gender must be male or female");
            }

            if (isValid == false)
                throw new ELibraryException(message.ToString());
            return isValid;
        }
        /// <summary>
        /// get age from date of birth
        /// </summary>
        /// <param name="dateOfBirth">date of birth</param>
        /// <returns>age</returns>
        public int GetAge(DateTime dateOfBirth)
        {
            var today = DateTime.Today;

            var a = (today.Year * 100 + today.Month) * 100 + today.Day;
            var b = (dateOfBirth.Year * 100 + dateOfBirth.Month) * 100 + dateOfBirth.Day;

            return (a - b) / 10000;
        }
        /// <summary>
        /// validate user login
        /// </summary>
        /// <param name="userID">userid</param>
        /// <param name="password">password</param>
        /// <returns>true/false on success or failure</returns>
        private bool ValidateLoginUserBL(string userID,string password)
        {
            bool isValid = true;
            StringBuilder message = new StringBuilder();

            if (userID == "")
            {
                isValid = false;
                message.Append(Environment.NewLine + "UserID Required");
            }
            if (password == "")
            {
                isValid = false;
                message.Append(Environment.NewLine + "Password is Required");
            }
            if (isValid == false)
                throw new ELibraryException(message.ToString());
            return isValid;
        }
        /// <summary>
        /// perform user login
        /// </summary>
        /// <param name="userID">user id</param>
        /// <param name="pasword">password</param>
        /// <returns>user object or null on success or failure</returns>
        public UserDetails UserLoginBL(string userID, string pasword)
        {
            UserDetails userDetailsObj = null;
            try
            {
                ELibraryUserDAL eLibDAL = new ELibraryUserDAL();
                if(ValidateLoginUserBL(userID,pasword))
                    userDetailsObj = eLibDAL.UserLoginDAL(userID, pasword);
            }

            catch (ELibraryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return userDetailsObj;

        }
        /// <summary>
        /// update user type from non subscriber to subscriber
        /// </summary>
        /// <param name="userObj">user object</param>
        /// <param name="payObj">payment object</param>
        /// <returns>true/false on success or failure</returns>
        public bool UpdateUserSubscriptionBL(UserDetails userObj,PaymentDetails payObj)
        {
            bool subscribed = false;
            try
            {
                ELibraryPaymentBL eLibPayObj = new ELibraryPaymentBL();
  
                if(eLibPayObj.VerifyPaymentBL(payObj))
                {
                    ELibraryUserDAL eLibUserObj = new ELibraryUserDAL();
                    subscribed = eLibUserObj.UpdateSubscriptionDAL(userObj);
                }
            }
            catch (ELibraryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return subscribed;
        }
        /// <summary>
        /// get count of registered users
        /// </summary>
        /// <returns>count</returns>
        public int GetRegisteredUserCountBL()
        {
            ELibraryUserDAL userDAL = new ELibraryUserDAL();
            try
            {
                int count = userDAL.GetRegisteredUserCountDAL();
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
        /// <summary>
        /// get count of subscribed users
        /// </summary>
        /// <returns>count</returns>
        public int GetSubscribedUserCountBL()
        {
            ELibraryUserDAL userDAL = new ELibraryUserDAL();
            try
            {
                int count = userDAL.GetSubscribedUserCountDAL();
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

        public bool UpdateDetailsUserBL(UserDetails userUpdateObj)
        {
            ELibraryUserDAL userDAL = new ELibraryUserDAL();
            try
            {
                bool Updated = userDAL.UpdateDetailsUserDAL(userUpdateObj);
                return Updated;
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
