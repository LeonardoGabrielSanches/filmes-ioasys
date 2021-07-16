using System.Collections.Generic;
using FilmesIoasys.Dominio.Entidades;

namespace FilmesIoasys.Dominio.Interfaces.Repositories
{
    public interface IUsuarioRepositorio
    {
        Usuario Salvar(Usuario usuario);
        Usuario RecuperaUsuarioPorEmail(string email);
        Usuario AtualizaStatusAtivo(Usuario usuario);
        IEnumerable<Usuario> RecuperaTodosUsuariosNaoAdmAtivos(int pagina, int tamanho);
    }
}