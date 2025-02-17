namespace WebAPI.Models
{
    public class UsuarioModel
    {

        public int Id { get; set; }

        public string? Name { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }

        // Relação com ClienteModel
        public List<ClienteModel>? Clientes { get; set; }

        // Relação com TarefaModel
        public List<TarefaModel>? Tarefas { get; set; }

    }
}
