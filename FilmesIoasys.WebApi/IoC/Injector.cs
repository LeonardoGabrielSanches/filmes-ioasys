using Microsoft.Extensions.DependencyInjection;
using FilmesIoasys.Infra.Data.Sql;
using FilmesIoasys.Dominio.Services;
using FilmesIoasys.Dominio.Interfaces.Services;
using FilmesIoasys.Dominio.Interfaces.Repositories;
using FilmesIoasys.Infra.Data.Sql.Repositories;

namespace FilmesIoasys.WebApi.IoC
{
    public static class Injector
    {
        public static void RegistraServicos(IServiceCollection service)
        {
            service.AddTransient<DataContext, DataContext>();
            service.AddTransient<IUsuarioServico, UsuarioServico>();
            service.AddTransient<IUsuarioRepositorio, UsuarioRepositorio>();
        }
    }
}