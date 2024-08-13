using WebAPI.Enums;

namespace WebAPI.Models
{
    public class TarefaModel
    {
        public int Id { get; set; }

        public string? Name { get; set; }
        public string? Description { get; set; }
        public StatusTarefa Status { get; set; }
    }
}
