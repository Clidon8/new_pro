using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Models
{
  public  class User
    {
        //מספר רץ של המשתמש במקום מספר זהות
        public int code { get; set; }
        //שם פרטי
        public string firstName { get; set; }
        //שם משפחה
        public string lastName { get; set; }
        
        public string userName { get; set; }
        
        public string email { get; set; }
        //סיסמת משתמש
        public string password { get; set; }
        //רשימת המסמכים המוקלדים של המשתמש
        public List<Document> documents { get; set; }
        //איזה סוג משתמש
        public bool isManeger { get; set; }
          
    }
}
