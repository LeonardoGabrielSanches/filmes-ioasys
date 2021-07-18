using Microsoft.Extensions.DependencyInjection;
using MoviesIoasys.Domain.Interfaces.Repositories;
using MoviesIoasys.Domain.Services.Movies;
using MoviesIoasys.Domain.Services.Users;
using MoviesIoasys.Infra.Data.Sql;
using MoviesIoasys.Infra.Data.Sql.Repositories;

namespace MoviesIoasys.WebApi.IoC
{
    public static class Injector
    {
        public static void RegisterServices(IServiceCollection service)
        {
            service.AddTransient<DataContext, DataContext>();
            service.AddTransient<CreateUserService, CreateUserService>();
            service.AddTransient<UpdateActiveStatusService, UpdateActiveStatusService>();
            service.AddTransient<LoginService, LoginService>();
            service.AddTransient<UpdateUserService, UpdateUserService>();
            service.AddTransient<CreateMovieService, CreateMovieService>();
            service.AddTransient<CreateVoteForMovieService, CreateVoteForMovieService>();

            service.AddTransient<IUsersRepository, UsersRepository>();
            service.AddTransient<IDirectorsRepository, DirectorsRepository>();
            service.AddTransient<IActorsRepository, ActorsRepository>();
            service.AddTransient<ICategoriesRepository, CategoriesRepository>();
            service.AddTransient<IMoviesRepository, MoviesRepository>();
            service.AddTransient<IVotesRepository, VotesRepository>();
        }
    }
}
