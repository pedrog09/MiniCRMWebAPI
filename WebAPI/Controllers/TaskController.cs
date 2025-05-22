using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Repositorios.Interfaces;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _tarefaRepositorio;

        public TaskController(ITaskRepository tarefaRepositorio)
        {
            _tarefaRepositorio = tarefaRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskModel>>> BuscarTodasTarefas()
        {
            List<TaskModel> tarefas = await _tarefaRepositorio.BuscarTodasTarefas();
            return Ok(tarefas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskModel>> BuscarPorId(int id)
        {
            TaskModel tarefas = await _tarefaRepositorio.BuscarPorId(id);
            return Ok(tarefas);
        }

        [HttpPost]
        public async Task<ActionResult<TaskModel>> Cadastrar([FromBody] TaskModel tarefaModel)
        {
            TaskModel tarefas = await _tarefaRepositorio.Adicionar(tarefaModel);
            return Ok(tarefas);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TaskModel>> Atualizar([FromBody] TaskModel tarefaModel, int id)
        {
            tarefaModel.Id = id;
            TaskModel tarefas = await _tarefaRepositorio.Atualizar(tarefaModel, id);
            return Ok(tarefas);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<TaskModel>> Apagar(int id)
        {
            bool apagado = await _tarefaRepositorio.Apagar(id);
            return Ok(apagado);
        }

    }
}
