using GestorDeContactos.Shared;
using System.Linq.Expressions;

namespace GestorDeContactos.Client.Services
{
    public interface IContactServices
    {
        Task SaveContact(Contact contact);
        Task DeleteContact(int id);
        Task<List<Contact>> GetList();
        Task<Contact> SearchContact(int id);
    }
}
