using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
  public  class Document
    {
        public List<Document> documents;
        //מספר רץ של המסמך
        public int code { get; set; }
        //שם המסמך
        public string documentsName { get; set; }
        //נתיב שלו
        public string documentPath { get; set; }
    }
}
