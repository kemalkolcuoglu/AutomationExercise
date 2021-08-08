using AutomationExercise.Models.Abstract;

namespace AutomationExercise.Models
{
    public class PeopleDatabaseSettings : IPeopleDatabaseSettings
    {
        public string CollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}