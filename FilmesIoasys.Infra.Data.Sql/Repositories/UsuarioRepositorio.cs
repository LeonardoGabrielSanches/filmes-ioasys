using System.Collections.Generic;
using System.Linq;
using FilmesIoasys.Dominio.Entidades;
using FilmesIoasys.Dominio.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FilmesIoasys.Infra.Data.Sql.Repositories
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly DataContext _context;
        private readonly DbSet<Usuario> _usuarios;

        public UsuarioRepositorio(
            DataContext context
        )
        {
            _context = context;
            _usuarios = _context.Set<Usuario>();
        }

        public Usuario AtualizaStatusAtivo(Usuario usuario)
        {
            _usuarios.Attach(usuario);
            _context.Entry(usuario).State = EntityState.Modified;
            _context.SaveChanges();

            return usuario;
        }

        public IEnumerable<Usuario> RecuperaTodosUsuariosNaoAdmAtivos(int pagina = 0, int tamanho = 5)
        {
            var usuarios = _usuarios.AsNoTracking().Where(usuario => usuario.Ativo
                                                                    && usuario.TipoUsuario != Dominio.Enums.TipoUsuario.Admin)
                                                                    .OrderBy(usuario => usuario.Nome);

            if (pagina > 0)
                return usuarios.Skip((pagina - 1) * tamanho).Take(tamanho);

            return usuarios;
        }

        public Usuario RecuperaUsuarioPorEmail(string email)
            => _usuarios.AsNoTracking().FirstOrDefault(usuario => usuario.Email == email);

        public Usuario Salvar(Usuario usuario)
        {
            _usuarios.Add(usuario);
            _context.SaveChanges();

            return usuario;
        }
    }
}