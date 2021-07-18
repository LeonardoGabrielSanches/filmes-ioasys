using System;
using MoviesIoasys.Domain.Entities;

namespace MoviesIoasys.WebApi.ViewModels.Categories
{
    public class CategoryViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public static implicit operator CategoryViewModel(Category category)
            => new CategoryViewModel()
            {
                Id = category.Id,
                Name = category.Name
            };
    }
}