namespace SistemaRaro;
using System.Text.RegularExpressions;

public class Validacao
{
    public static List<Status> ValidarUsuario(List<Usuario> usuarios, Usuario usuario)
    {
        List<Status> Validacoes = new List<Status>();
        if (usuario.Senha.Length < 8)
        {
            Validacoes.Add(Status.SENHA_NAO_TEM_8_CARACTERES);
        }
        if (!usuario.Senha.Any(c => Char.IsUpper(c)))
        {
            Validacoes.Add(Status.SENHA_NAO_TEM_LETRA_MAIUSCULA);
        }
        if (!usuario.Senha.Any(c => Char.IsNumber(c)))
        {
            Validacoes.Add(Status.SENHA_NAO_TEM_NUMEROS);
        }
        if (!Regex.Match(usuario.Senha, @"[!@#$%^&*().]").Success)
        {
            Validacoes.Add(Status.SENHA_NAO_TEM_CHAR_ESPECIAL);
        }
        if (EmailJaCadastrado(usuarios, usuario))
        {
            Validacoes.Add(Status.EMAIL_EXISTENTE);
        }
        if (ConfirmacaoNaoCoincide(usuario))
        {
            Validacoes.Add(Status.CONFIRMACAO_INVALIDA);
        }
        if (Validacoes.Count == 0)
        {
            Validacoes.Add(Status.USUARIO_VALIDO);
        }
        return Validacoes;
    }

    private static bool EmailJaCadastrado(List<Usuario> usuarios, Usuario usuario) =>
        usuarios.Exists(user => user.Email == usuario.Email);

    private static bool ConfirmacaoNaoCoincide(Usuario usuario) =>
        usuario.Senha != usuario.Confirmacao;
}
