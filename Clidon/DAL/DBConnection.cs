using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DAL 
{
   public class DBConnection
    {
        //נתיב החיבור למונגו
        protected MongoClient connection = new MongoClient(@"mongodb://localhost:27017/?readPreference=primary&appname=MongoDB%20Compass&directConnection=true&ssl=false");
        //הגדרת משתנה מהסוג של מונגו
        protected MongoDatabaseBase database;
        //הגדרת האוסף החדש מסוג קובץ גסון
        protected IMongoCollection<BsonDocument> collection;

        public DBConnection()
        {
            //איתחול האוסף במונגו בשם קלידון
            database = (MongoDatabaseBase)connection.GetDatabase("Clidon");
        }
    }
}
