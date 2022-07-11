using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using Models;

namespace DAL
{
    public class UserTBL : DBConnection
    {
        //הגדרת רשימת משתמשים 
        List<User> users = new List<User>();

        public UserTBL()
        {
            //הגדרת האוסף החדש של המונגו שאליו יוכנסו שתי מסמכים מסמך משתמש ומסמך אות 
            collection = database.GetCollection<BsonDocument>("user");
        }
        //פונקציה שמחזירה את כל המשתמשים
        public List<User> GetAll()
        {
            List<BsonDocument> documents = collection.Find(new BsonDocument()).ToList();
            foreach (BsonDocument document in documents)
            {
                users.Add(new User()
                {
                    code = int.Parse(document["code"].ToString()),
                    firstName = document["firstName"].ToString(),
                    lastName = document["lastName"].ToString(),
                    password = document["password"].ToString(),
                    isManeger = document["isManger"].ToBoolean(),
                    documents = DocumentsToList(document["documents"].AsBsonArray)

                });


            }
            return users;
        }

        public BsonArray CreateBsonUser(List<User> u)
        {
            throw new NotImplementedException();
        }

        //פונקציה שמחזירה את מספרי המשתמשים
        public int GetCount()
        {
            List<User>  u = new List<User>();
            int max = 0;
            // return GetAll().Count;
           u= GetAll();
          
            for(int a=0;a< u.Count ;a++)
            {
                if (u[a].code > max)
                {
                    max = u[a].code;
                }
            }
            return max;
        }
        //ממיר את הנתונים מהמסמך שנראה כקובץ גסון לרשימה 
        public List<Document> DocumentsToList(BsonArray bsonDocument)
        {
            List<Document> documents = new List<Document>();
            Document document;
            foreach (BsonDocument bdDocument in bsonDocument)
            {
                document = new Document()
                {
                    code = int.Parse((bsonDocument["code"]).ToString()),
                    documentsName = bsonDocument["documentsName"].ToString(),
                    documentPath = bsonDocument["documentPath"].ToString()
                };
            }
            return documents;
        }
        //הוספת משתמש
        public void AddUser(User u)
        {
            collection.InsertOne(CreateBsonUser(u));
        }
        //עדכון משתמש
        public void Update(User user)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("code", user.code);
            collection.FindOneAndUpdate(filter, CreateBsonUser(user));
        }
        //מחיקת משתמש
        public void Delete(User user)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("code", user.code);
            collection.FindOneAndDelete(filter);
        }
        //(פונקציה שמקבלת את האובייקט משתמש (כמודל)ומחזירה אובייקט חדש מסוג משתמש(מלא בנתונים  
        public BsonDocument CreateBsonUser(User u)
        {
            BsonDocument document = new BsonDocument
            {
                {"code" ,u.code},
                { "firstName" ,u.firstName },
                {"lastName",u.lastName },
                {"password",u.password },
                {"isManger",u.isManeger  },
                { "documents",GetDocuments(u.documents)}
            };
            return document;
        }
        //פונקציה שמכינה אובייקט לרשימת המסמכים
        private BsonValue createBasonDocument(Document document)
        {
            BsonDocument bdocument = new BsonDocument
            {
                {"code",document.code },
                {"documentsName",document.documentsName },
                {"documentPath",document.documentPath }
            };
            return bdocument;
        }
    //פונקציה שמוסיפה לרשימת הדפים המוקלדים דף מוקלד חדש
    private BsonArray GetDocuments(List<Document> documents)
    {
        BsonArray bsonArray = new BsonArray { };
        foreach (Document document in documents)
        {
            bsonArray.Add(createBasonDocument(document));
        }
        return bsonArray;
    }
        //פונקציה שמקבלת קובץ גסון ומחזירה אובייקט משתמש
        public User TransformfromBsomToUser(BsonDocument bduser)
        {
            User user;
            if (bduser != null)
            {
                try
                {
                    user = new User()
                    {
                        code =int.Parse( bduser["code"].ToString()),
                        firstName = bduser["firstName"].ToString(),
                        lastName = bduser["lastName"].ToString(),
                        password = bduser["password"].ToString(),
                        isManeger = bduser["isManeger"].ToBoolean(),
                        documents = DocumentsToList(bduser["documents"].AsBsonArray)
                    };
                    return user;
                }
                catch (Exception ex)
                {

                }
            }
            return null;
        }
        
        //כניסה ע"י שם משתמש וסיסמא:
        public User FindUserByUserName(string userName, string password)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("username", userName);
            //רשימה של גסון
            var userList = collection.Find(filter).ToList();
            User u = TransformfromBsomToUser(userList.Where(user => user["password"].ToString() == password).FirstOrDefault());
            return u;
        }
    }
}
