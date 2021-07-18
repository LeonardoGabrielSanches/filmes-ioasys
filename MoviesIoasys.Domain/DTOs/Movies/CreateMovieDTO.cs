using System.Collections.Generic;
using System.Linq;
using MoviesIoasys.Domain.Entities;

namespace MoviesIoasys.Domain.DTOs.Movies
{
    public class CreateMovieDTO
    {
        public CreateMovieDTO(string title,
                              string description,
                              string director,
                              IEnumerable<string> cast,
                              string category)
        {
            Title = title;
            Description = description;
            Director = director;
            Cast = cast;
            Category = category;
        }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public string Director { get; private set; }

        public IEnumerable<string> Cast { get; private set; }

        public string Category { get; private set; }

        public static implicit operator Movie(CreateMovieDTO createMovieDTO)
            => new Movie(title: createMovieDTO.Title,
                         description: createMovieDTO.Description,
                         director: new Director(name: createMovieDTO.Director),
                         cast: createMovieDTO.Cast.Select(actor => new Actor(name: actor)).ToList(),
                         category: new Category(name: createMovieDTO.Category));
    }
}