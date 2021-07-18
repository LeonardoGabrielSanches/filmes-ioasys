using System;
using System.Collections.Generic;
using System.Linq;
using MoviesIoasys.Domain.Entities;

namespace MoviesIoasys.Domain.DTOs.Movies
{
    public class CreateMovieDTO
    {
        public CreateMovieDTO(string title,
                              string description,
                              Guid directorId,
                              IEnumerable<Guid> castIds,
                              Guid categoryId)
        {
            Title = title;
            Description = description;
            DirectorId = directorId;
            CastIds = castIds;
            CategoryId = categoryId;
        }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public Guid DirectorId { get; private set; }

        public IEnumerable<Guid> CastIds { get; private set; }

        public Guid CategoryId { get; private set; }

        public static implicit operator Movie(CreateMovieDTO createMovieDTO)
            => new Movie(title: createMovieDTO.Title,
                         description: createMovieDTO.Description,
                         directorId: createMovieDTO.DirectorId,
                         castIds: createMovieDTO.CastIds.ToList(),
                         categoryId: createMovieDTO.CategoryId);
    }
}