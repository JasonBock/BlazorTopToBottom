using DataAccess.Dal;
using System.Net.Http.Json;

namespace DataAccess.Client;

public class HttpDataAccess(HttpClient httpClient) : IDataAccess
{
    public Task DeletePerson(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<PersonEntity?> GetPersonById(int id)
    {
        var result = await httpClient.GetFromJsonAsync<PersonEntity>($"api/GetData?id={id}");
        return result;
    }

    public async Task SavePerson(PersonEntity person)
    {
        var response = await httpClient.PostAsJsonAsync("api/SaveData", person);
    }
}
