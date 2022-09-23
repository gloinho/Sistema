namespace Teste;

[TestClass]
public class SistemaTest
{
    [TestMethod]
    public void TestPrimeiroCadastroNoSistema()
    {
        Sistema sistema = new Sistema();
        Usuario usuario = new Usuario("anastacio@email.com", "Gandalf159.", "Gandalf159.");
        List<Status> actual = sistema.Cadastrar(usuario);
        List<Status> expected = new List<Status> { Status.USUARIO_VALIDO, Status.CADASTRADO };
        CollectionAssert.AreEquivalent(expected, actual);
    }

    [TestMethod]
    public void TestSeUmEmailJaExiste()
    {
        Sistema sistema = new Sistema();
        Usuario usuario = new Usuario("anastacio@email.com", "Gandalf159.", "Gandalf159.");
        sistema.Cadastrar(usuario);
        Usuario usuario2 = new Usuario("anastacio@email.com", "Sol123456789.", "Sol123456789.");
        List<Status> actual = sistema.Cadastrar(usuario2);
        List<Status> expected = new List<Status> { Status.EMAIL_EXISTENTE };
        CollectionAssert.AreEquivalent(expected, actual);
    }

    [TestMethod]
    public void TestSenhaInvalida()
    {
        Sistema sistema = new Sistema();
        Usuario usuario = new Usuario("anastacio@email.com", "", "");
        List<Status> actual = sistema.Cadastrar(usuario);
        List<Status> expected = new List<Status>
        {
            Status.SENHA_NAO_TEM_NUMEROS,
            Status.SENHA_NAO_TEM_8_CARACTERES,
            Status.SENHA_NAO_TEM_CHAR_ESPECIAL,
            Status.SENHA_NAO_TEM_LETRA_MAIUSCULA
        };
        CollectionAssert.AreEquivalent(expected, actual);
    }

    [TestMethod]
    public void TestSeConfirmacaoEstaValida()
    {
        Sistema sistema = new Sistema();
        Usuario usuario = new Usuario("anastacio@email.com", "Gandalf159.", "ronaldO1234.");
        List<Status> actual = sistema.Cadastrar(usuario);
        List<Status> expected = new List<Status> { Status.CONFIRMACAO_INVALIDA };
        CollectionAssert.AreEquivalent(expected, actual);
    }

    [TestMethod]
    public void TestSenhaInvalidaSemNumeros()
    {
        Sistema sistema = new Sistema();
        Usuario usuario = new Usuario(
            "anastacio@email.com",
            "AnastacioGomes...",
            "AnastacioGomes..."
        );
        List<Status> actual = sistema.Cadastrar(usuario);
        List<Status> expected = new List<Status> { Status.SENHA_NAO_TEM_NUMEROS, };
        CollectionAssert.AreEquivalent(expected, actual);
    }

    [TestMethod]
    public void TestSenhaInvalidaTamanhoMenorQueOito()
    {
        Sistema sistema = new Sistema();
        Usuario usuario = new Usuario("anastacio@email.com", "Ana...7", "Ana...7");
        List<Status> actual = sistema.Cadastrar(usuario);
        List<Status> expected = new List<Status> { Status.SENHA_NAO_TEM_8_CARACTERES, };
        CollectionAssert.AreEquivalent(expected, actual);
    }

    [TestMethod]
    public void TestSenhaInvalidaSemCaracterEspecial()
    {
        Sistema sistema = new Sistema();
        Usuario usuario = new Usuario(
            "anastacio@email.com",
            "AnastacioGomes123",
            "AnastacioGomes123"
        );
        List<Status> actual = sistema.Cadastrar(usuario);
        List<Status> expected = new List<Status> { Status.SENHA_NAO_TEM_CHAR_ESPECIAL, };
        CollectionAssert.AreEquivalent(expected, actual);
    }

    [TestMethod]
    public void TestSenhaInvalidaSemLetraMaiuscula()
    {
        Sistema sistema = new Sistema();
        Usuario usuario = new Usuario(
            "anastacio@email.com",
            "anastaciogomes123...",
            "anastaciogomes123..."
        );
        List<Status> actual = sistema.Cadastrar(usuario);
        List<Status> expected = new List<Status> { Status.SENHA_NAO_TEM_LETRA_MAIUSCULA, };
        CollectionAssert.AreEquivalent(expected, actual);
    }
}
