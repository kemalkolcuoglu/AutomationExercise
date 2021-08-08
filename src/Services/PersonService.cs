using AutomationExercise.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using AutomationExercise.Services.Abstract;
using AutomationExercise.Models.Abstract;
using MongoDB.Bson;

namespace AutomationExercise.Services
{
    public class PersonService : IPersonService
    {
        private readonly IMongoCollection<Person> _collection;

        public PersonService(IPeopleDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _collection = database.GetCollection<Person>(settings.CollectionName);
        }

        public IEnumerable<Person> Get() =>
            _collection.Find(person => true).ToList();

        public Person Get(string id) =>
            _collection.Find<Person>(person => person.Id == id).FirstOrDefault();

        public Person Create(Person person)
        {
            _collection.InsertOne(person);
            return person;
        }

        public long Update(string id, Person personIn)
        {
            ReplaceOneResult result = _collection.ReplaceOne(x => x.Id == id, personIn);
            return result.ModifiedCount;
        }

        public long Remove(string id)
        {
            DeleteResult result = _collection.DeleteOne(person => person.Id == id);
            return result.DeletedCount;
        }
    }
}