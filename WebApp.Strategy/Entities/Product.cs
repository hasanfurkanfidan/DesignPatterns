using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Strategy.Entities
{
    public class Product
    {
        [BsonId]
        [Key]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        [Column(TypeName ="decimal(18,2)")]
        [BsonRepresentation(MongoDB.Bson.BsonType.Decimal128)]

        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string AppUserId { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.DateTime)]

        public DateTime CreatedDate { get; set; }
    }
}
