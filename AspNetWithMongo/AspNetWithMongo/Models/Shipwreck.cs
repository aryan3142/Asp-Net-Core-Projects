using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetWithMongo.Models
{
    [BsonIgnoreExtraElements] //tells mongodb driver to not include or map the extra elements while fetching data
    public class Shipwreck
    {
        public ObjectId Id { get; set; }

        [BsonElement("feature_type")]
        public string FeatureType { get; set; } 

        [BsonElement("chart")]
        public string Chart { get; set; }

        [BsonElement("latdec")]
        public double Latitude { get; set; }

        [BsonElement("londec")]
        public double Longitude { get; set; }
    }
}
