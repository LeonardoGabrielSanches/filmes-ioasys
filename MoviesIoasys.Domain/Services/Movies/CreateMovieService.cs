using MoviesIoasys.Domain.DTOs.Movies;
using MoviesIoasys.Domain.Entities;
using MoviesIoasys.Domain.Interfaces.Repositories;

namespace MoviesIoasys.Domain.Services.Movies
{
    public class CreateMovieService
    {
        private readonly IDirectorsRepository _directorsRepository;
        private readonly IActorsRepository _actorsRepository;
        private readonly IMoviesRepository _moviesRepository;
        private readonly ICategoriesRepository _categoriesRepository;

        public CreateMovieService(IDirectorsRepository directorsRepository,
                                  IActorsRepository actorsRepository,
                                  IMoviesRepository moviesRepository,
                                  ICategoriesRepository categoriesRepository)
        {
            _directorsRepository = directorsRepository;
            _actorsRepository = actorsRepository;
            _moviesRepository = moviesRepository;
            _categoriesRepository = categoriesRepository;
        }

        public Movie CreateMovie(CreateMovieDTO createMovieDTO)
        {
            var movie = (Movie)createMovieDTO;

            if (!movie.IsValid)
                return new Movie().GetInvalidMovie(movie.NotificationError);

            if (!FoundCategory(movie.Category))
                _categoriesRepository.Save(movie.Category);

            if (!FoundDirector(movie.Director))
                _directorsRepository.Save(movie.Director);

            foreach (var actor in movie.Cast)
                if (!FoundActor(actor))
                    _actorsRepository.Save(actor);

            _moviesRepository.Save(movie);

            return movie;
        }

        private bool FoundCategory(Category category)
            => _categoriesRepository.GetByCategoryByName(category.Name)?.Exists() ?? false;

        private bool FoundDirector(Director director)
            => _directorsRepository.GetByDirectorByName(director.Name)?.Exists() ?? false;

        private bool FoundActor(Actor actor)
            => _actorsRepository.GetByActorByName(actor.Name)?.Exists() ?? false;
    }
}