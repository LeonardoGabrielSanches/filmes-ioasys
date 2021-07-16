using FilmesIoasys.Dominio.Entidades;
using FilmesIoasys.Dominio.Interfaces.Repositories;
using FilmesIoasys.Dominio.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace FilmesIoasys.Dominio.Testes
{
    [TestClass]
    public class UsuarioTestes
    {
        private const string
            email = "email@email.com",
            senha = "senha",
            nome = "nome",
            senhaIncorreta = "senhaIncorreta";

        private const Enums.TipoUsuario
            tipoUsuario = Enums.TipoUsuario.Admin;

        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioTestes()
        {
            _usuarioRepositorio = Substitute.For<IUsuarioRepositorio>();
        }

        private Usuario RecuperaUsuario()
            => new Usuario(
                email: email,
                senha: Criptografia.CriptografarSenha(senha),
                nome: nome,
                tipoUsuario: tipoUsuario);

        private Usuario UsuarioInvalido
            => new Usuario().RecuperaUsuarioInvalido("Usu�rio inv�lido");

        private UsuarioServico ObtemServico()
            => new UsuarioServico(_usuarioRepositorio);

        #region Entidade

        [TestMethod]
        public void Entidade_RetornaVerdadeiro_SeVazio()
        {
            var usuario = new Usuario();

            Assert.IsTrue(usuario.Vazio());
        }

        #endregion

        #region Service

        #region CriarUsuario

        [TestMethod]
        public void Service_AoCriarUsuario_RetornaEntidadeInvalida_SeUsuarioInvalido()
        {
            var usuarioServico = ObtemServico();

            var usuario = usuarioServico.CriaUsuario(UsuarioInvalido);

            Assert.IsFalse(usuario.IsValid);
        }

        [TestMethod]
        public void Service_AoCriarUsuario_RetornaEntidadeInvalida_SeEmailJaExiste()
        {
            var usuario = RecuperaUsuario();

            _usuarioRepositorio.RecuperaUsuarioPorEmail(usuario.Email).Returns(usuario);

            var usuarioServico = ObtemServico();

            var usuarioCriado = usuarioServico.CriaUsuario(usuario);

            Assert.IsFalse(usuarioCriado.IsValid);
        }

        [TestMethod]
        public void Service_AoCriarUsuario_RetornaUsarioCriado()
        {
            var usuario = RecuperaUsuario();

            _usuarioRepositorio.RecuperaUsuarioPorEmail(usuario.Email).Returns(new Usuario());

            var usuarioServico = ObtemServico();

            var usuarioCriado = usuarioServico.CriaUsuario(usuario);

            Assert.AreEqual(usuarioCriado, usuario);
        }

        #endregion

        #region Logion

        [TestMethod]
        public void Service_AoRealizarLogin_RetornaEntidadeInvalida_SeEmailNaoCadastrado()
        {
            _usuarioRepositorio.RecuperaUsuarioPorEmail(email).Returns(new Usuario());

            var usuarioServico = ObtemServico();

            var usuarioLogin = usuarioServico.Login(email, senha);

            Assert.IsFalse(usuarioLogin.IsValid);
        }

        [TestMethod]
        public void Service_AoRealizarLogin_RetornaEntidadeInvalida_SeSenhaIncorreta()
        {
            var usuarioSenhaIncorreta = new Usuario(
                email: email,
                senha: Criptografia.CriptografarSenha(senhaIncorreta),
                nome: nome,
                tipoUsuario: tipoUsuario);

            _usuarioRepositorio.RecuperaUsuarioPorEmail(email).Returns(usuarioSenhaIncorreta);

            var usuarioServico = ObtemServico();

            var usuarioLogin = usuarioServico.Login(email, senha);

            Assert.IsFalse(usuarioLogin.IsValid);
        }

        [TestMethod]
        public void Service_AoRealizarLogin_RetornaEntidade()
        {
            var usuario = RecuperaUsuario();

            _usuarioRepositorio.RecuperaUsuarioPorEmail(email).Returns(usuario);

            var usuarioServico = ObtemServico();

            var usuarioLogin = usuarioServico.Login(email, senha);

            Assert.IsNotNull(usuarioLogin);
        }

        #endregion

        #region AtualizarStatusAtivo

        [TestMethod]
        public void Service_AoMudarStatusAtivo_RetornaEntidadeInvalida()
        {
            _usuarioRepositorio.RecuperaUsuarioPorEmail(email).Returns(new Usuario());

            var usuarioServico = ObtemServico();

            var usuarioAtualizado = usuarioServico.MudaStatusAtivo(email, ativo: false);

            Assert.IsFalse(usuarioAtualizado.IsValid);
        }

        [TestMethod]
        [DataRow(true)]
        [DataRow(false)]
        public void Service_AoMudarStatusAtivo_RetornaEntidadeComStatusAtualizado(bool ativo)
        {
            var usuario = RecuperaUsuario();

            _usuarioRepositorio.RecuperaUsuarioPorEmail(email).Returns(usuario);

            var usuarioServico = ObtemServico();

            var usuarioAtualizado = usuarioServico.MudaStatusAtivo(email, ativo);

            Assert.AreEqual(usuarioAtualizado.Ativo, ativo);
        }

        #endregion

        #endregion
    }
}