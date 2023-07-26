using GestorDeContactos.Shared;
using Microsoft.EntityFrameworkCore;

namespace GestorDeContactos.Server.DAL
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }
        public DbSet<Contact> Contacts { get; set; }
    }
}
