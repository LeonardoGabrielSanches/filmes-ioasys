using System;
using MoviesIoasys.Domain.Entities;

namespace MoviesIoasys.WebApi.ViewModels.Directors
{
    public class DirectorViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public static implicit operator DirectorViewModel(Director director)
            => new DirectorViewModel()
            {
                Id = director.Id,
                Name = director.Name
            };
    }
}