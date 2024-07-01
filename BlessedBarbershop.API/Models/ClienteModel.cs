namespace BlessedBarbershop.API.Models;

public class ClienteModel
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Sobrenome { get; set; } = string.Empty;
    public string? Email { get; set; } = string.Empty;
    public string DDD { get; set; } = string.Empty;
    public string NumeroCelular { get; set; } = string.Empty;
    public DateTime DataCadastro { get; set; }
    public int Pontos { get; set; } = 0;
}
