using System;
using System.Collections.Generic;

namespace MoviesIoasys.Domain.Entities
{
    public class Director : Person
    {
        public Director(Guid id,
                        string name) : base(name)
        {
            Id = id;

            Validate();
        }


        public Director(string name) : base(name)
        {
            Validate();
        }

        public ICollection<Movie> Movies { get; private set; }
    }
}
