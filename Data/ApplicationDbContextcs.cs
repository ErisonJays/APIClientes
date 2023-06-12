using APIClientes.Modelos;
using Microsoft.EntityFrameworkCore;

namespace APIClientes.Data
{
    public class ApplicationDbContextcs : DbContext //Hedera de DbContext de Microsoft.EntityFrameworkCore
    {

        public ApplicationDbContextcs(DbContextOptions<ApplicationDbContextcs> option) : base(option)
        {

        }

        public DbSet <Cliente> Clientes{ get; set; }
        public DbSet <User> Users { get; set; }
    }
}
