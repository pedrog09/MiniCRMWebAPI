using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Repositorios.Interfaces;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _usuarioRepositorio;

        public UserController(IUserRepository usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }



        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> BuscarTodosUsuarios()
        {
            List<UserModel> usuarios = await _usuarioRepositorio.BuscarTodosUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> BuscarPorId(int id)
        {
            UserModel usuario = await _usuarioRepositorio.BuscarPorId(id);
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> Cadastrar([FromBody] UserModel usuarioModel)
        {
            UserModel usuario = await _usuarioRepositorio.Adicionar(usuarioModel);
            return Ok(usuario);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserModel>> Atualizar([FromBody] UserModel usuarioModel, int id)
        {
            usuarioModel.Id = id;
            UserModel usuario = await _usuarioRepositorio.Atualizar(usuarioModel, id);
            return Ok(usuario);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<UserModel>> Apagar(int id)
        {
            bool apagado = await _usuarioRepositorio.Apagar(id);
            return Ok(apagado);
        }

    }
}
