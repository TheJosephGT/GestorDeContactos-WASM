using GestorDeContactos.Shared;
using System.Linq.Expressions;
using System.Net.Http.Json;

namespace GestorDeContactos.Client.Services
{
    public class ContactService : IContactServices
    {
        private readonly HttpClient _httpClient;
        public ContactService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task DeleteContact(int id)
        {
            await _httpClient.DeleteAsync($"api/contacts/{id}");
        }

        public async Task<List<Contact>> GetList()
        {
            return await _httpClient.GetFromJsonAsync<List<Contact>>($"api/contacts");
        }

        public async Task SaveContact(Contact contact)
        {
           await _httpClient.PostAsJsonAsync($"api/contacts", contact);
        }

        public async Task<Contact> SearchContact(int id)
        {
            return await _httpClient.GetFromJsonAsync<Contact>($"api/contacts/{id}");
        }
    }
}
