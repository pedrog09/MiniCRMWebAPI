﻿using WebAPI.Enums;

namespace WebAPI.Models
{
    public class TarefaModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public StatusTarefa Status { get; set; }
        public int? UsuarioId { get; set; }
        public virtual UsuarioModel? Usuario { get; set; }
        public DateTime? Ending { get; set; } // Nova propriedade
    }
}
