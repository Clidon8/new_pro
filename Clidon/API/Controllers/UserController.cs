using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Models;
using BLL;
using System.Web;
using System.IO;

namespace API.Controllers
{
    //עברית
    // str = @"C:\Users\שטרן\Desktop\מסכי פרוייקט\black.png";
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        UserBl userBl = new UserBl();
        [Route("insert")]
        [HttpPost]
        //הוספת משתמש למערכת
        public int Insert(User user)
        {
            try
            {
               
                userBl.AddUser(user);
                return user.code;
            }
            catch (Exception)
            {
                return -1;
            }
        }
        [Route("AllUser")]
        [HttpGet]
        //הפונקציה מביאה את כל המשתמשים הקימים במערכת
        public List<User> AllUser()
        {
            try
            {
                return userBl.GetAll();
            }
            catch (Exception)
            {
                return null;
            }
        }
        [Route("LOGIN/{password}/{lname}/{fname}")]
        [HttpGet]
        //בדיקה אם מחובר
        public string LOGIN(string password, string lname, string fname)
        {
            List<User> li = userBl.GetAll();
            List<User> l1 = userBl.GetAll();
            User u1;
            try
            {
                u1 = li.FirstOrDefault(l => (l.lastName == lname && l.firstName == fname && l.password == password));
            }
            catch
            {
                return "no";
            }
            if (u1 == null)
                return "no";
            else
            {
                if (IsMeneger(password, u1.code))
                    return u1.code + " " + u1.password + " " + u1.lastName + " " + u1.firstName + " " + true; 
               return u1.code + " " + u1.password + " " + u1.lastName + " " + u1.firstName + " " + false;
                //return u1.code+" "+password+" "+ lname + " " + fname;
            }
            //if (IsMeneger(password) && u1.firstName == fname && u1.lastName == lname)
            //    return u1.password;
            //if (u1.firstName == fname && u1.lastName == lname)
            //    return u1.firstName + " " + u1.lastName;
            //return "";
        }
        [Route("isSignIn/{password}")]
        [HttpGet]
        //בדיקה אם מחובר לא נכון
        public string isSignIn(string password)
        {
            List<User> li = userBl.GetAll();
            User u1;

            try
            {
                //מוצא את הסיסמא הראשונה ששווה ואם מצא כנראה שהיא קימת
                u1 = li.First(l => l.password == password);

            }
            catch
            {
                return "";
            }
            if (u1 == null)
                return "";
            if (IsMeneger(password,u1.code))
                return u1.code + "," + u1.password;
            return u1.code + "," + u1.firstName + "," + u1.lastName;
        }
        //בדיקה אם השם משתמש קיים
        [Route("IsName/{fname}/{lname}")]
        [HttpGet]
        public bool IsName(string fname, string lname)
        {
            List<User> li = userBl.GetAll();
            User u1;
            try
            {
                //בדיקה אם מוצא שם כזה
                u1 = li.Find(l => l.lastName == lname && l.firstName == fname);
            }
            catch
            {
                return false;
            }
            if (u1 != null)
                return true;
            return false;

        }
        [Route("getcount")]
        [HttpGet]
        //(מספר רץ(בפועל הוא באנגולר
        public int GetCount()
        {
            return userBl.GetCount();
        }
        [Route("ChangePassword/{passwordold}/{passwordnew}")]
        [HttpGet]
        //עדכון סיסמא במערכת
        public int ChangePassword(string passwordold, string passwordnew)
        {
            User userold = new User();
            User usernew = new User();
            List<User> li = userBl.GetAll();
            User u1 = new User();
            User u2 = new User();
            try
            {
                //מוצא את הסיסמא הראשונה ששווה ואם מצא כנראה שהיא קימת
                u1 = li.First(l => l.password == passwordold);
                //מחפש אם יש אדם שהסיסמא שלו שווה לסיסמא החדשה
                u2 = li.Find(l => l.password == passwordnew);
            }
            catch
            {
                //אם האדם שרוצה לשנות סיסמא לא קיים במערכת
                return -1;//false
            }
            //אם הסיסמא החדשה קיימת 
            if (u2 != null)
            {
                //אם הסיסמא  החדשה קימת כבר במערכת
                return 0;
            }
            else
            {
                usernew.code = u1.code;
                usernew.firstName = u1.firstName;
                usernew.lastName = u1.lastName;
                usernew.password = passwordnew;
                usernew.isManeger = u1.isManeger;
                usernew.documents = u1.documents;
                usernew.email = u1.email;
                userBl.UpdateUser(usernew);

                //return usernew;
                //אם יכל לעדכן סיסמא חדשה
                return 1;

            }
        }
        [Route("UpdateUser1/{codeuser}/{WhatChange}/{DataChange}")]
        [HttpGet]
        //עדכון שם משפחה חדש
        //מקבל מהמערכת את הקוד משתמש ואת השם שרוצה לשנות ומשנה
        public int UpdateUser1(int codeuser, string WhatChange, string DataChange)
        {

            User usernew = new User();
            List<User> li = userBl.GetAll();
            User u1 = new User();
            try
            {
                //מוצא את השם הראשון שווה ואם מצא כנראה שהוא קים
                u1 = li.First(l => l.code == codeuser);
            }
            catch
            {
                //אם האדם שרוצה לשנות שם לא קיים במערכת
                return -1;//false
            }

            //אם קיים אדם כזה
            if (u1 != null)
            {
                //כל נתוני המשתמש ללא שינויים
                usernew.code = u1.code;
                usernew.firstName = u1.firstName;
                usernew.lastName = u1.lastName;
                usernew.password = u1.password;
                usernew.isManeger = u1.isManeger;
                usernew.documents = u1.documents;
                usernew.email = u1.email;
                //WhatChange-איזה נתון לשנות
                //DataChange-תוכן השינוי
                //לפי הנתון שקבלנו שונה נשנה נדרוס את הנתון הקודם ונשים נתון חדש
                switch (WhatChange)
                {
                    case "lastname":
                        //string newlastname = DataChange;
                        usernew.lastName = DataChange;
                        break;
                    case "firstname":
                        // string newfirstname = DataChange;
                        usernew.firstName = DataChange;
                        break;
                    case "password":
                        // string newpassword = DataChange;
                        usernew.password = DataChange;
                        break;
                    default:
                        usernew.password = u1.password;
                        break;
                }
                userBl.UpdateUser(usernew);
            }
            return 0;
        }
        [Route("IsMeneger/{passwordIsMeneger}")]
        [HttpGet]
        //בדיקה אם אני מנהל
        public bool IsMeneger(string passwordIsMeneger , int codeUser)
        {
            List<User> li = userBl.GetAll();
            User u1 = new User();
            try
            {
                //מחפש אם יש אדם שהסיסמא שלו שווה לסיסמא שבודקים אם הוא מנהל
                // u1 = li.Find(l => l.password == passwordIsMeneger);
                u1 = li.FirstOrDefault(l => l.password == passwordIsMeneger && l.code == codeUser);
            }
            catch
            {
                //בטוח לא מנהל
                return false;
            }
            //אם יש אדם שהסיסמא שלו נמצאה
            if (u1 != null)
            {
                //תבדוק אם הוא מנהל
                if (u1.isManeger)
                {
                    return true;
                }
            }
            return false;
        }
        [Route("IsPasswordNew/{passwordNEW}/{ISpassword}")]
        [HttpGet]

        //בדיקה אם הסיסמא שהכניס שווה לסיסמא שכתוב בדוק סיסמא ואם היא לא קימת כבר במערכת
        public bool IsPasswordNew(string passwordNEW, string ISpassword)
        {
            List<User> li = userBl.GetAll();
            User u1 = new User();
            try
            {
                //מחפש אם יש אדם שהסיסמא שלו שווה לסיסמא החדשה שרוצה להכניס
                u1 = li.Find(l => l.password == passwordNEW);
            }
            catch
            {
                return false;
            }
            //אם הסיסמא אינה קימת במערכת עדיין
            if (u1 == null)
            {
                if (passwordNEW == ISpassword)
                {
                    return true;
                }
            }
            return false;
        }
        [Route("UpdetIsMeneger/{ISmeneger}/{password}/{lastname}/{firstname}")]
        [HttpGet]
        //עדכון סוג משתמש
        public bool UpdetIsMeneger(bool ISmeneger, string password, string lastname, string firstname)
        {
            List<User> li = userBl.GetAll();
            User u1 = new User();
            User newuser = new User();
            User deletuser = new User();
            //בודק אם הסיסמא קימת
            try
            {
                // u1 = li.Find(l => l.password == password);
                u1 = li.FirstOrDefault(l => (l.lastName == lastname && l.firstName == firstname && l.password == password));

            }
            catch
            {
                return false;
            }
            //אם הסיסמא  קימת במערכת 
            if (u1 != null)
            {
                //אם הוא מנהל תעדכן אותו כמנהל
                if (ISmeneger)
                {
                    newuser.code = u1.code;
                    newuser.firstName = u1.firstName;
                    newuser.lastName = u1.lastName;
                    newuser.password = u1.password;
                    newuser.isManeger = true;
                    newuser.documents = u1.documents;
                    userBl.UpdateUser(newuser);
                    return true;
                }
                //עדכון לא מנהל
                if (!ISmeneger)
                {
                    newuser.code = u1.code;
                    newuser.firstName = u1.firstName;
                    newuser.lastName = u1.lastName;
                    newuser.password = u1.password;
                    newuser.isManeger = false;
                    newuser.documents = u1.documents;
                    userBl.UpdateUser(newuser);
                    return true;
                }

            }
            return false;
        }
        //מחיקת משתמשים
        [Route("Delet/{CodeUser}")]
        [HttpGet]
        public void Delet(int CodeUser)
        {
            List<User> li = userBl.GetAll();
            User u1 = new User();
            try
            {
                u1 = li.Find(l => l.code == CodeUser);
            }
            catch
            {
            }
            if (u1 != null)
            {
                userBl.Delete(u1);
            }
        }
        [HttpGet]
        [Route("finduserbyusernameandpassword/{userName}/{password}")]

        //בדיקה אם משתמש קיים ע"פ שם משתמש וסיסמא
        public string FindUserByUserNameAndPassword(string userName, string password)
        {
            try
            {
                User user = userBl.FindUserByUsrNameAndPassword(userName, password);
                return user + "helllo";
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }
        //[Route("Paypal")]
        //[HttpGet]
        //הפונקציה נקראת בכפתור של כניסה לאיזור אישי אם הוא מנהל נפנה אותו לאיזור האישי שלו ואם לא נפנה אותו למסך של PAYPAL 
        //ואחרי שהוא ישלם נפנה אותו לאיזור האישי שלו
        //הפונקציה הנל בודקת האם המשתמש קיים ואם כן אם הוא מנהל או משתמש פשוט
        //public bool Paypal(string userfirstname,string userlastname,string password,bool IsM)
        //{
        //    List<User> li = userBl.GetAll();
        //    User u1 = new User();

        //    User newuser = new User();
        //    User deletuser = new User();
        //    //בודק אם הסיסמא קימת
        //    try
        //    {
        //        u1 = li.Find(l => l.password == password ) ;

        //    }
        //    catch
        //    {

        //        return false;
        //    }
        //    //אם הסיסמא  קימת במערכת 
        //    if (u1 != null)
        //    {
        //        //אם השם המלא קיים והוא לא מנהל
        //        if(u1.firstName==userfirstname && u1.lastName==userlastname && !IsM)
        //        {
        //            return true;
        //        }
        //        return false;
        //    }
        //    return false;
        //}
        [Route("FileToText")]
        [HttpPost]
        //מחזיר את הטקסט המוקלד
        public string FileToText()
        {
            Algoritem algorithm = new Algoritem();
            string text;
            HttpPostedFile file = HttpContext.Current.Request.Files[0];
            string path = HttpContext.Current.Server.MapPath("~/Content/Files/" + file.FileName);
            file.SaveAs(path);
            //אנגלית
            //string  str = @"C:\Users\שטרן\Desktop\מסכי פרוייקט\black.png";
            // string str = @"C:\Users\שטרן\Documents\קטעי קוד לאלגוריתם הראשי\ניסוים_לאלגוריתם\ניסוים_לאלגוריתם\bin\Debug\hello.png";
            //string str = File.ReadAllText(@"C:\Users\שטרן\Desktop\גיבוי פרויקט גדול\7 -סוףףףףףף\path.txt");
            //string str = @"C:\Users\שטרן\Pictures\תמונה6.png";
            //"C:\Users\שטרן\Documents\קטעי קוד לאלגוריתם הראשי\ניסוים_לאלגוריתם\ניסוים_לאלגוריתם\bin\Debug\hello2.png"
            // string str = @"C:\Users\שטרן\Documents\קטעי קוד לאלגוריתם הראשי\ניסוים_לאלגוריתם\ניסוים_לאלגוריתם\bin\Debug\hello2.png";
            //string str="";
            //if (number==1)
            // str = @"C:\Users\שטרן\Desktop\משפטים להקלדה לפרויקט\hello world.png";
            //if (number == 2)
            //    str = @"C:\Users\שטרן\Desktop\משפטים להקלדה לפרויקט\אישאישאיש.png";
            //if(number==3)
            //    str= @"C:\Users\שטרן\Desktop\משפטים להקלדה לפרויקט\תמונה להקלדה באנגלית.png";
             text =algorithm.imagetostring(path);
            return text;
        }






        //פונקציה שמביאה קוד משתמש
        [Route("CodeUser/{lastname}/{firstname}/{passwordNew}")]
        [HttpGet]
        public string CodeUser(string lastname,string firstname,string passwordNew)
        {
            User u1 = new User();
            List<User> li= userBl.GetAll();
            try
            {
                u1 = li.FirstOrDefault(l => (l.lastName == lastname && l.firstName == firstname ));
            }
            catch
            {
                return false+","+null;
            }
            if (u1 != null)
            {
               if(ChangePassword1(passwordNew, u1.code) )
                {
                    return true + "," + u1.code+","+ u1.isManeger;
                }
                return false + "," + u1.code;
            }
            //אם השם מכיל יותר משם אחד לדוגמא משה חיים הוא לא ימצא כזה משתמש כי הוא מחלק לפי רווחים
            return false + "," + null;
        }

        //-----------------------------------------------------------------------------------------------
        Algoritem algoritem = new Algoritem();
        //מקבל נתיב
        [Route("Get/{file}")]
        [HttpGet]
        public string Get(string file)
        {
            return "value";
        }
        //[Route("Files")]
        //[HttpGet]
        //public static string Files()
        //{
        //    //HttpPostedFile file = HttpContext.Current.Request.Files[0];
        //    //string path = HttpContext.Current.Server.MapPath("~/Content/Files/" + file.FileName);
        //    //file.SaveAs(path);
           
        //  // string text = algoritem.imagetostring(path);
          
        // string   text = "hello good morning";
        //    return text;
        //}


        //פונקציה שמחליפה סיסמא אם ששכח סיסמא
        [Route("ChangePassword1/{passwordnew}/{codeUser}")]
        [HttpGet]
        //עדכון סיסמא חדשה במערכת
        public bool ChangePassword1( string passwordnew,int codeUser)
        {
            User userold = new User();
            User usernew = new User();
            List<User> li = userBl.GetAll();
            User u1 = new User();
            User u2 = new User();
            User u = new User();
            try
            {
                // מחפש את המשתמש העונה על הקוד
                u = li.First(c => c.code == codeUser);
               
            }
            catch
            {
                //אם האדם שרוצה לשנות סיסמא לא קיים במערכת
                return false;
            }
                usernew.code = u.code;
                usernew.firstName = u.firstName;
                usernew.lastName = u.lastName;
                usernew.password = passwordnew;
                usernew.isManeger = u.isManeger;
                usernew.documents = u.documents;
                usernew.email = u.email;
                userBl.UpdateUser(usernew);
                return true;
             }
        [Route("UpdetIsMeneger1/{ISmeneger}/{password}/{fname}/{lname}")]
        [HttpGet]
        //עדכון סוג משתמש
        public string UpdetIsMeneger1(bool ISmeneger, string password,string fname,string lname)
        {
            List<User> li = userBl.GetAll();
            User u1 = new User();
            User newuser = new User();
            User deletuser = new User();
            //בודק אם הסיסמא קימת
            try
            {
                u1 = li.FirstOrDefault(l => (l.lastName == lname && l.firstName == fname && l.password == password));
            }
            catch
            {
                return false+","+u1.password+","+u1.firstName+","+u1.lastName;
            }
            //אם הסיסמא  קימת במערכת 
            if (u1 != null)
            {
                //אם הוא מנהל תעדכן אותו כמנהל
                if (ISmeneger)
                {
                    newuser.code = u1.code;
                    newuser.firstName = u1.firstName;
                    newuser.lastName = u1.lastName;
                    newuser.password = u1.password;
                    newuser.isManeger = true;
                    newuser.documents = u1.documents;
                    userBl.UpdateUser(newuser);
                    return  true + "," + u1.password + "," + u1.firstName + "," + u1.lastName;
                }
                //עדכון לא מנהל
                if (!ISmeneger)
                {
                    newuser.code = u1.code;
                    newuser.firstName = u1.firstName;
                    newuser.lastName = u1.lastName;
                    newuser.password = u1.password;
                    newuser.isManeger = false;
                    newuser.documents = u1.documents;
                    userBl.UpdateUser(newuser);
                    return true + "," + u1.password + "," + u1.firstName + "," + u1.lastName; 
                }
            }
            return false + "," + u1.password + "," + u1.firstName + "," + u1.lastName; 
        }
    }
}