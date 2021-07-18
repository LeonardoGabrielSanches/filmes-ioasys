using MoviesIoasys.Domain.DTOs.Movies;
using MoviesIoasys.Domain.Entities;
using MoviesIoasys.Domain.Interfaces.Repositories;
using System.Collections.Generic;

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

        private Movie Movie;

        public Movie CreateMovie(CreateMovieDTO createMovieDTO)
        {
            Movie = createMovieDTO;

            if (!Movie.IsValid)
                return new Movie().GetInvalidMovie(Movie.NotificationError);

            _moviesRepository.Save(Movie);

            return Movie;
        }

        private void HandleCategory()
        {
            var category = _categoriesRepository.GetByCategoryByName(Movie.Category.Name);

            if (!FoundCategory(category))
                category = _categoriesRepository.Save(Movie.Category);

            Movie.ApplyCategoryId(category);
        }

        private void HandleDirector()
        {
            var director = _directorsRepository.GetByDirectorByName(Movie.Director.Name);

            if (!FoundDirector(director))
                director = _directorsRepository.Save(Movie.Director);

            Movie.ApplyDirectorId(director);
        }

        private void HandleCast()
        {
            var cast = new List<Actor>();

            foreach (var castActor in Movie.Cast)
            {
                var actor = _actorsRepository.GetActorByName(castActor.Name);

                if (!FoundActor(actor))
                    actor = _actorsRepository.Save(castActor);

                cast.Add(actor);
            }

            Movie.ApplyActorMovies(cast);
        }

        private bool FoundCategory(Category category)
            => category?.Exists() ?? false;

        private bool FoundDirector(Director director)
            => director?.Exists() ?? false;

        private bool FoundActor(Actor actor)
            => actor?.Exists() ?? false;
    }
}