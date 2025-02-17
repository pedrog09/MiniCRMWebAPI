using Microsoft.EntityFrameworkCore;
using WebAPI.Data.Map;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class SistemaDeTarefasDBContext : DbContext
    {

        public SistemaDeTarefasDBContext(DbContextOptions<SistemaDeTarefasDBContext> options) : base(options)
        {
        }

        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<TarefaModel> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
