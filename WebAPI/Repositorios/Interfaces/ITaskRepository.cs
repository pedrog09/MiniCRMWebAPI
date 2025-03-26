using WebAPI.Models;

namespace WebAPI.Repositorios.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<TaskModel>> BuscarTodasTarefas();
        Task<TaskModel> BuscarPorId(int id);
        Task<TaskModel> Adicionar(TaskModel tarefa);
        Task<TaskModel> Atualizar(TaskModel tarefa, int id);
        Task<bool> Apagar(int id);
    }
}
