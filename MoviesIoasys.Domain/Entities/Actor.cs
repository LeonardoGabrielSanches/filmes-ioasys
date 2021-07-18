﻿using System.Collections.Generic;
using Flunt.Notifications;
using Flunt.Validations;

namespace MoviesIoasys.Domain.Entities
{
    public class Actor : Person
    {
        public Actor(string name) : base(name)
        {
            Validate();
        }

        public ICollection<Movie> Movies { get; private set; }
    }
}