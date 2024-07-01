using Microsoft.EntityFrameworkCore;
using OficinaMecanica.Models;

namespace OficinaMecanica.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Oficina>? Oficinas { get; set; }
        public DbSet<Funcionario>? Funcionarios { get; set; }

    }
}
