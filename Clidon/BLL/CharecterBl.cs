using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;

namespace BLL
{
   public class CharecterBl
    {
        //לא שימושי
       
            CharecterTBL charecterTBL = new CharecterTBL();
            //הוספת תו חדש למערכת
            public void AddCharecter(Charecter c)
            {
                charecterTBL.AddCharecter(c);
            }
            //עדכון תויים קימים
            public void UpdatCharecter(Charecter c)
            {
                charecterTBL.Update(c);
            }
            //מחיקת תו
            public void DeleteCharecter(Charecter c)
            {
                charecterTBL.Delete(c);
            }
            //מספר רץ של התו
            public int GetCountCharecter()
            {
                return charecterTBL.GetCount();
            }
        }
}
