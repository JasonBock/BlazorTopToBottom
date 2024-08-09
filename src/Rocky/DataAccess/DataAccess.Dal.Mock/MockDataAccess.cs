namespace DataAccess.Dal.Mock;

public class MockDataAccess : IDataAccess
{
    public Task DeletePerson(int id)
    {
        var person = MockDatabase.People.FirstOrDefault(p => p.Id == id);
        if (person != null)
            MockDatabase.People.Remove(person);
        return Task.CompletedTask;
    }

    public Task<PersonEntity?> GetPersonById(int id)
    {
        return Task.FromResult(MockDatabase.People.FirstOrDefault(p => p.Id == id));
    }

    public Task SavePerson(PersonEntity person)
    {
        if (person.Id == 0)
        {
            person.Id = MockDatabase.People.Max(p => p.Id) + 1;
            MockDatabase.People.Add(person);
        }
        else
        {
            var existingPerson = MockDatabase.People.FirstOrDefault(p => p.Id == person.Id);
            if (existingPerson != null)
            {
                existingPerson.Name = person.Name;
                existingPerson.Address = person.Address;
                existingPerson.City = person.City;
                existingPerson.State = person.State;
                existingPerson.Zip = person.Zip;
            }
        }
        return Task.CompletedTask;
    }
}
