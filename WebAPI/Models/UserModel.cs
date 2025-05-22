﻿﻿﻿namespace WebAPI.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }
        public string UserKey { get; set; } = Guid.NewGuid().ToString("N"); // Generate a unique key

        // Relação com ClienteModel
        public List<ClientModel>? Clientes { get; set; }

        // Relação com TarefaModel
        public List<TaskModel>? Tarefas { get; set; }
    }
}
