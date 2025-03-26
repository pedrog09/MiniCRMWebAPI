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

        public DbSet<ClientModel> Clientes { get; set; }
        public DbSet<UserModel> Usuarios { get; set; }
        public DbSet<TaskModel> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new ClientMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new TaskMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
