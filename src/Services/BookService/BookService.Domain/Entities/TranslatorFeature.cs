using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookService.Domain.Entities
{
    public class TranslatorFeature
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        [BsonRepresentation(BsonType.Double)]
        public double Rating { get; set; }
        [BsonRepresentation(BsonType.Int32)]
        public int ReadCount { get; set; }
        [BsonRepresentation(BsonType.Int32)]
        public int ReviewCount { get; set; }
    }
}
