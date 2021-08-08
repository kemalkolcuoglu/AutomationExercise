using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace AutomationExercise.Models
{
    public class Person
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [Required, MaxLength(15)]
        public string Name { get; set; }

        [Required, MaxLength(15)]
        public string Surname { get; set; }
    }
}