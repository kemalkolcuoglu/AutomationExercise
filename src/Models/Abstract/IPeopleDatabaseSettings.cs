namespace AutomationExercise.Models.Abstract
{
    public interface IPeopleDatabaseSettings
    {
        string CollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}