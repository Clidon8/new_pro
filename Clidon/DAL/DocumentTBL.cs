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
    public class DocumentTBL : DBConnection
    {
            //אתחול רשימה של מסמכים מוקלדים
            List<Document> Documents = new List<Document>();
            public DocumentTBL()
            {
                //איתחול המסמך של המסמכים במונגו
                collection = database.GetCollection<BsonDocument>("document");
            }
            //פונקציה שמחזירה את רשימת המסמכים הקימים במערכת
            public List<Document> GetAll()
            {
                List<BsonDocument> documents = collection.Find(new BsonDocument()).ToList();
                foreach (BsonDocument document in documents)
                {
                    Documents.Add(new Document()
                    {
                        code = (int)document["code"],
                        documentsName = document["documentsName"].ToString(),
                        documentPath = document["documentPath"].ToString()
                    });


                }
                return Documents;
            }

        public BsonArray CreateBsonDocument(List<Document> d)
        {
            throw new NotImplementedException();
        }

        //פונקציה שמחזירה את מספר הזיהוי של כל מסמך ברשימה
        public int GetCount()
            {
            List<Document> u = new List<Document>();
            int max = 0;
            // return GetAll().Count;
            u = GetAll();
            for (int a = 0; a < u.Count; a++)
            {
                if (u[a].code > max)
                {
                    max = u[a].code;
                }
            }
            return max;
        }
            //הוספת מסמך למערכת
            public void AddDocument(Document d)
            {
                collection.InsertOne(CreateBsonDocument(d));
            }

            //עדכון תווים
            public void UpdateDocument(Document d)
            {
                var filter = Builders<BsonDocument>.Filter.Eq("code", d.code);
                collection.FindOneAndUpdate(filter, CreateBsonDocument(d));
            }
            //מחיקת תווים
            public void DeleteDocument(Document d)
            {
                var filter = Builders<BsonDocument>.Filter.Eq("code", d.code);
                collection.FindOneAndDelete(filter);
            }
            //הגדרת תו חדש
            public BsonDocument CreateBsonDocument(Document d)
            {
                BsonDocument document = new BsonDocument
            {
                {"code" ,d.code},
                { "documentsName" ,d.documentsName },
                {"documentPath",d.documentPath },
            };
                return document;
            }
        }
    }




