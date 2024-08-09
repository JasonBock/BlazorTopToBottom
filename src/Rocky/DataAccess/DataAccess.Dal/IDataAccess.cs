namespace DataAccess.Dal
{
    public interface IDataAccess
    {
        Task<PersonEntity?> GetPersonById(int id);
        Task SavePerson(PersonEntity person);
        Task DeletePerson(int id);
    }
}
