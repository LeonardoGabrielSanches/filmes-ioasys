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