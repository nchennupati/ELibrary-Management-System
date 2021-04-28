using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    /// <summary>
    /// document properties
    /// </summary>
    public class DocumentDetails
    {
        public int DocumentID { get; set; }
        public string DocumentName { get; set; }
        public string DocumentDescription { get; set; }
        public string DocumentPath { get; set; }
        public int DocumentTypeID { get; set; }
        public int DisciplineID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
        public DateTime UploadDate { get; set; }
    }
}
