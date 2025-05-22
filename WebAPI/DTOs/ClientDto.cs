namespace WebAPI.DTOs
{
    public class ClientDto
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Tipo { get; set; }
        public string? CNPJ { get; set; }
        public string? CPF { get; set; }
    }
}
