
using Microsoft.EntityFrameworkCore;

namespace ProvaFolha.Models
{
     public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}

        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Folha> Folhas {get; set;}

    }
}