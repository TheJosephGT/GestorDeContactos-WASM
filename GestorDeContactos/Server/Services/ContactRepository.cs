using GestorDeContactos.Server.DAL;
using GestorDeContactos.Shared;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Expressions;

namespace GestorDeContactos.Server.Services
{
    public class ContactRepository : IContactRepository
    {
        private Contexto _contexto;

        public ContactRepository(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> Exists(int id)
        {
            return await _contexto.Contacts.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> Insert(Contact contact)
        {
            _contexto.Contacts.AddAsync(contact);
            bool salida = await _contexto.SaveChangesAsync() > 0;
            _contexto.Entry(contact).State = EntityState.Detached;
            return salida;
        }

        public async Task<bool> Delete(int id)
        {
            var eliminado = await _contexto.Contacts.Where(p => p.Id == id).SingleOrDefaultAsync();

            if(eliminado != null)
            {
                _contexto.Contacts.Remove(eliminado);
                bool salida = await _contexto.SaveChangesAsync() >= 0;
                _contexto.Entry(eliminado).State = EntityState.Detached;
                return salida;
            }

            return false;
        }

        public async Task<bool> Update(Contact contact)
        {
            var existe = await _contexto.Contacts.FindAsync(contact.Id);

            if(existe != null)
            {
                _contexto.Entry(existe).CurrentValues.SetValues(contact);
                bool salida = await _contexto.SaveChangesAsync() > 0;
                _contexto.Entry(contact).State |= EntityState.Detached;
                return salida;
            }

            return false;
        }

        public async Task<bool> Save(Contact contact)
        {
            if(! await Exists(contact.Id))
                return await Insert(contact);
            else
                return await Update(contact);
        }

        public async Task<Contact> Search(int id)
        {
            return await _contexto.Contacts.FindAsync(id);
        }

        public async Task<List<Contact>> GetList(Expression<Func<Contact, bool>> criterio)
        {
            return _contexto.Contacts.AsNoTracking().Where(criterio).ToList();
        }
    }
}
