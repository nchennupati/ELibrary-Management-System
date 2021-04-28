using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    /// <summary>
    /// user properties
    /// </summary>
    public class UserDetails
    {
        public string UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string UserAddress { get; set; }
        public string LandLineNumber { get; set; }
        public string AreaOfInterest { get; set; }
        public string MobileNumber { get; set; }
        public string Gender { get; set; }
        public string UserType { get; set; }
        public DateTime DateOfRegistration { get; set; }
        public string Pasword { get; set; }
    }
}
