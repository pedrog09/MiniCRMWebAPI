namespace WebAPI.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }
        public int UsuarioId {  get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }
        public string? Tipo { get; set; } // "empresa" ou "pessoa"
        public string? CNPJ { get; set; }
        public string? CPF { get; set; }


    }
}
