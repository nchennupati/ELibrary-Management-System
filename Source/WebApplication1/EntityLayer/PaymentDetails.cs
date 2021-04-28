using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    /// <summary>
    /// payment properties
    /// </summary>
    public class PaymentDetails
    {
        public string CreditCardNumber { get; set; }
        public string CreditCardName { get; set; }
        public string CVV { get; set; }
        public int ExpiryMonth { get; set; }
        public int ExpiryYear { get; set; }
        public double Amount { get; set; }
    }
}
