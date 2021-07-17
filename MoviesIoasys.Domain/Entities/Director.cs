using System.Collections.Generic;
using Flunt.Notifications;
using Flunt.Validations;

namespace MoviesIoasys.Domain.Entities
{
    public class Director : Person
    {
        public IEnumerable<Movie> Movies { get; private set; }
    }
}
