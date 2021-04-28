using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using ExceptionLayer;
using System.Text.RegularExpressions;
namespace BusinessLogicLayer
{
    /// <summary>
    /// class containg payment business language
    /// </summary>
    public class ELibraryPaymentBL
    {
        /// <summary>
        /// method to verify payment
        /// </summary>
        /// <param name="paymentObj">payment details object</param>
        /// <returns>true/false</returns>
        public bool VerifyPaymentBL(PaymentDetails paymentObj)
        {
            StringBuilder sb = new StringBuilder();
            bool validated = true;
            if (paymentObj.CreditCardName == null)
            {
                sb.AppendLine("Credit Card Name Cannot be Empty");
                validated = false;
            }
            if (!Regex.IsMatch(paymentObj.CreditCardName, "[A-Za-z]{1,50}"))
            {
                validated = false;

                sb.Append(Environment.NewLine + "Credit Card Name must contain only characters");
            }

            if (paymentObj.CreditCardNumber == "")
            {
                sb.AppendLine("Credit Card Number Cannot be Empty");
                validated = false;
            }
            if ((paymentObj.CreditCardNumber.Length != 16))
            {
                sb.AppendLine("Credit Card Number should be 16 digits");
                validated = false;
            }

            if (paymentObj.CVV == "")
            {
                sb.AppendLine("CVV Number should not be Empty");
                validated = false;
            }
            if (paymentObj.CVV.Length != 3)
            {
                sb.AppendLine("CVV Number should be 3 digits");
                validated = false;
            }
            if (paymentObj.ExpiryMonth == 0)
            {
                sb.AppendLine("Month should not be Empty");
                validated = false;
            }
            if (paymentObj.ExpiryMonth < 1 || paymentObj.ExpiryMonth > 12)
            {
                sb.AppendLine("Enter valid Month number[1-12]");
                validated = false;
            }
            if (paymentObj.ExpiryYear == 0)
            {
                sb.AppendLine("Year should not be Empty");
                validated = false;
            }
            if (paymentObj.ExpiryYear < DateTime.Now.Year)
            {
                sb.Append("Expiry year invalid");
                validated = false;
            }
            if (paymentObj.ExpiryYear == DateTime.Now.Year)
                if (paymentObj.ExpiryMonth < DateTime.Now.Month)
                {
                    sb.AppendLine("Enter expiry month and year");
                    validated = false;
                }
            if (validated == false)
            {
                throw new ELibraryException(sb.ToString());
            }
           return validated;
        }
    }
}
