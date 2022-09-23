namespace SistemaRaro;

public class Sistema
{
    public List<Usuario> Usuarios = new List<Usuario>();

    public List<Status> Cadastrar(Usuario usuario)
    {
        List<Status> validacao = Validacao.ValidarUsuario(Usuarios, usuario);
        if (validacao.Contains(Status.USUARIO_VALIDO))
        {
            validacao.Add(Status.CADASTRADO);
            Usuarios.Add(usuario);
        }
        return validacao;
    }
}
