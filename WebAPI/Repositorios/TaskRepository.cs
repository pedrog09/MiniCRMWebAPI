using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;
using WebAPI.Repositorios.Interfaces;

namespace WebAPI.Repositorios
{
    public class TaskRepository : ITaskRepository
    {
        private readonly SistemaDeTarefasDBContext _dbContext; 
        public TaskRepository(SistemaDeTarefasDBContext sistemaDeTarefasDBContext) 
        {
            _dbContext = sistemaDeTarefasDBContext;
        }

        public async Task<TaskModel> BuscarPorId(int id)
        {
            return await _dbContext.Tarefas
                .Include(x => x.Usuario)
                .FirstOrDefaultAsync(x=> x.Id == id);
        }

        public async Task<List<TaskModel>> BuscarTodasTarefas()
        {
            return await _dbContext.Tarefas
                .Include(x => x.Usuario)
                .ToListAsync();
        }
        public async Task<TaskModel> Adicionar(TaskModel tarefa)
        {
            await _dbContext.Tarefas.AddAsync(tarefa);
            await _dbContext.SaveChangesAsync();

            return tarefa;
        }
        public async Task<TaskModel> Atualizar(TaskModel tarefa, int id)
        {
            TaskModel tarefaPorId = await BuscarPorId(id);

            if (tarefaPorId == null) 
            {
                throw new Exception($"Tarefa para o ID: {id} não foi encontrado no banco");
            }
           
            tarefaPorId.Name = tarefa.Name;
            tarefaPorId.Description = tarefa.Description;
            tarefaPorId.Status = tarefa.Status;
            tarefaPorId.UsuarioId = tarefa.UsuarioId;

            _dbContext.Tarefas.Update(tarefaPorId);
            await _dbContext.SaveChangesAsync();

            return tarefaPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            TaskModel tarefaPorId = await BuscarPorId(id);

            if (tarefaPorId == null)
            {
                throw new Exception($"Tarefa para o ID: {id} não foi encontrado no banco");
            };

            _dbContext.Tarefas.Remove(tarefaPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
