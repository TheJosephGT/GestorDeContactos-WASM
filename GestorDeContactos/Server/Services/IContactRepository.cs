using GestorDeContactos.Shared;
using System.Linq.Expressions;

namespace GestorDeContactos.Server.Services
{
    public interface IContactRepository
    {
        Task<bool>Exists(int id);
        Task<bool>Insert(Contact contact);
        Task<bool>Update(Contact contact);
        Task<bool>Save(Contact contact);
        Task<bool>Delete(int id);
        Task<Contact>Search(int id);
        Task<List<Contact>> GetList(Expression<Func<Contact, bool>> criterio);
    }
}
