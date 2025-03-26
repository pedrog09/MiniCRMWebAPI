using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;
using WebAPI.Repositorios.Interfaces;

namespace WebAPI.Repositorios
{
    public class UserRepository : IUserRepository
    {
        private readonly SistemaDeTarefasDBContext _dbContext; 
        public UserRepository(SistemaDeTarefasDBContext sistemaDeTarefasDBContext) 
        {
            _dbContext = sistemaDeTarefasDBContext;
        }

        public async Task<UserModel> BuscarPorId(int id)
        {
            return await _dbContext.Usuarios?.FirstOrDefaultAsync(x=> x.Id == id);
        }

        public async Task<UserModel> BuscarPorNome(string name)
        {
            return await _dbContext.Usuarios?.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<List<UserModel>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }
        public async Task<UserModel> Adicionar(UserModel usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();

            return usuario;
        }
        public async Task<UserModel> Atualizar(UserModel usuario, int id)
        {
            UserModel usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId == null) 
            {
                throw new Exception($"Usuario para o ID: {id} não foi encontrado no banco");
            }
           
            usuarioPorId.Name = usuario.Name;
            usuarioPorId.Email = usuario.Email;
            usuarioPorId.Password = usuario.Password;
            usuarioPorId.Role = usuario.Role;

            _dbContext.Usuarios.Update(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            return usuarioPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            UserModel usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"Usuario para o ID: {id} não foi encontrado no banco");
            };

            _dbContext.Usuarios.Remove(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
