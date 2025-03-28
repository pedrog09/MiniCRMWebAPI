using WebAPI.Enums;

namespace WebAPI.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Enums.TaskStatus Status { get; set; }
        public int? UsuarioId { get; set; }
        public virtual UserModel? Usuario { get; set; }
        public DateTime? Ending { get; set; } // Nova propriedade
    }
}
