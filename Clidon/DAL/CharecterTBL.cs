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
    public class CharecterTBL:DBConnection
    {
        //אתחול רשימה של תווים
        List<Charecter> charecters = new List<Charecter>();
        public CharecterTBL()
        {
            //איתחול המסמך של התווים במונגו
            collection = database.GetCollection<BsonDocument>("charecter");
        }
        //פונקציה שמחזירה את רשימת התווים הקימים במערכת
        public List<Charecter> GetAll()
        {
            List<BsonDocument> documents = collection.Find(new BsonDocument()).ToList();
            foreach (BsonDocument document in documents)
            {
                charecters.Add(new Charecter()
                {
                    
                    character = (char)document["character"],
                    dataPath = document["dataPath"].ToString(),
                    P = document["P"].ToDouble()
                });


            }
            return charecters;
        }
        //פונקציה שמחזירה את מספר הזיהוי של כל תו ברשימה
        public int GetCount()
        {
            return GetAll().Count;
        }
        //הוספת תווים למערכת
        public void AddCharecter(Charecter c)
        { 
            collection.InsertOne(CreateBsonCharacter(c));
        }
       
        //עדכון תווים
        public void Update(Charecter c)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("character", c.character);
            collection.FindOneAndUpdate(filter, CreateBsonCharacter(c));
        }
        //מחיקת תווים
        public void Delete(Charecter c)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("character", c.character);
            collection.FindOneAndDelete(filter);
        }
        //הגדרת תו חדש
        public BsonDocument CreateBsonCharacter(Charecter c)
        {
            BsonDocument document = new BsonDocument
            {
                {"character" ,c.character},
                { "dataPath" ,c.dataPath },
                {"P",c.P },
            };
            return document;
          

        }
    }
}
