using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    /// <summary>
    /// purchased properties
    /// </summary>
    public class PurchasedDetails
    {
        public int PurchasedID { get; set; }
        public int DocumentID { get; set; }
        public string UserID { get; set; }
        public DateTime PurchasedDate { get; set; }
        public PurchasedDetails()
        {
            PurchasedDate = DateTime.Now;
        }
    }
}
