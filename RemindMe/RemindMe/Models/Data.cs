using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;

namespace RemindMe.Models
{
    public class Data
    {
        public static IMongoClient client { get; set; }
        public static IMongoDatabase database { get; set; }

        public static String MongoConnection = Environment.GetEnvironmentVariable("MONGODB_URI");
        public static String MongoDatabase = "RemindMeDB";
        
        public static IMongoCollection<Models.Event> Event_Collection { get; set; }
        internal static void ConnectToMongo()
        {
            try
            {
                client = new MongoClient(MongoConnection);
                database = client.GetDatabase(MongoDatabase);

            }
            catch(Exception)
            {
                throw;
            }
        }
        
       
    }
    
}

