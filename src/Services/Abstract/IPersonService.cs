using System.Collections.Generic;
using AutomationExercise.Models;

namespace AutomationExercise.Services.Abstract
{
    public interface IPersonService
    {
        IEnumerable<Person> Get();
        Person Get(string id);
        Person Create(Person person);
        long Update(string id, Person personIn);
        long Remove(string id);
    }
}