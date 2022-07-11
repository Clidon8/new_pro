using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BLL
{
   //ניהול משתמשים
    public class UserBl
    {
        UserTBL userTbl = new UserTBL();
        //הוספת משתמש חדש למערכת
        public void AddUser(User user)
        {
            userTbl.AddUser(user);
        }
        //עדכון משתמשים קימים
        public void UpdateUser(User user)
        {
            userTbl.Update(user);
        }
        //מחיקת משתמש
        public void Delete(User user)
        {
            userTbl.Delete(user);
        }
        //מספר רץ של המשתמשים
        public int GetCount()
        {
            return userTbl.GetCount();
        }
       
        //כל המשתמשים
        public List<User> GetAll()
        {
           return userTbl.GetAll();
        }
        public BsonArray users(List<User> u)
        {
            u = GetAll();
            return userTbl.CreateBsonUser(u);
        }
        //כניסה ע"י שם משתמש וסיסמא:
        public User FindUserByUsrNameAndPassword(string usrName, string password)
        {
            return userTbl.FindUserByUserName(usrName, password);
        }

    }
}
