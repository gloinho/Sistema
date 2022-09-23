namespace SistemaRaro;

public class Usuario
{
    public string Email { get; set; }
    public string Senha { get; set; }
    public string Confirmacao { get; set; }

    public Usuario(string email, string senha, string confirmacao)
    {
        Email = email;
        Senha = senha;
        Confirmacao = confirmacao;
    }
}
