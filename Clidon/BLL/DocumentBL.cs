using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;

namespace BLL
{
   public class DocumentBL
    {
        DocumentTBL documentTbl = new DocumentTBL();
        //הוספת מסמך מוקלד חדש למערכת
        public void AddDocument(Document document)
        {
            documentTbl.AddDocument(document);
        }
        //מחיקת מסמך מוקלד מן המערכת
        public void Delete(Document document)
        {
            documentTbl.DeleteDocument(document);
        }
        //מספר רץ של המסמכים
        public int GetCount()
        {
            return documentTbl.GetCount();
        }
        //כל המסמכים
        public List<Document> GetAll()
        {
            return documentTbl.GetAll();
        }

    }
}
