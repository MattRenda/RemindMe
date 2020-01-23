using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace RemindMe.Models
{
    [BsonIgnoreExtraElements]
    public class Event
    {
        public String email { get; set;}
        public String name { get; set; }
        public String date { get; set; }
        public String time { get; set; }
    }
}