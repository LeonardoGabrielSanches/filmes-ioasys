using System.Collections.Generic;
using FilmesIoasys.Dominio.Entidades;

namespace FilmesIoasys.Dominio.Interfaces.Services
{
    public interface IUsuarioServico
    {
        Usuario CriaUsuario(Usuario usuario);
        Usuario Login(string email, string senha);
        Usuario MudaStatusAtivo(string email, bool ativo);
        IEnumerable<Usuario> RecuperaUsuariosNaoAdmAtivos(int pagina, int tamanho);
    }
}