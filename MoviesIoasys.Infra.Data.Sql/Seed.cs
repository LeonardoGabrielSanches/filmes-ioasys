using MoviesIoasys.Domain.Entities;
using System.Collections.Generic;

namespace MoviesIoasys.Infra.Data.Sql
{
    public class Seed
    {
        public IEnumerable<Actor> Actors()
        {
            return new List<Actor>()
            {
                new Actor(id: System.Guid.Parse("aecd9fdc-c732-4066-a620-c83d931e6893"),
                          name: "Leonardo DI Caprio"),
                 new Actor(id: System.Guid.Parse("b73b3d56-ce9a-4644-a339-aaf96f26a3ad"),
                          name: "Morgan Freeman"),
                  new Actor(id: System.Guid.Parse("0a9d5004-3c5e-4e70-bda9-26cf5310476c"),
                          name: "Robert De Niro")
            };
        }

        public IEnumerable<Director> Directors()
        {
            return new List<Director>()
            {
                new Director(id: System.Guid.Parse("91d89dbf-4099-4f8f-b48f-f57cdabcf773"),
                          name: "Howard Hawks"),
                 new Director(id: System.Guid.Parse("636303b9-2906-4f40-8b52-92cdbb687b00"),
                          name: "Martin Scorsese"),
                  new Director(id: System.Guid.Parse("7dd08154-4793-496e-82cd-e2640edfff82"),
                          name: "Sidney Lumet")
            };
        }

        public IEnumerable<Category> Categories()
        {
            return new List<Category>()
            {
                new Category(id: System.Guid.Parse("92bad319-e3d1-4818-ab99-57bfdaa68ab4"),
                          name: "Ação"),
                 new Category(id: System.Guid.Parse("54fdf761-83c3-4362-b0fd-8069b49d8313"),
                          name: "Comédia"),
                  new Category(id: System.Guid.Parse("8eb9f73f-4530-497b-95ce-56ba59556564"),
                          name: "Drama")
            };
        }
    }
}
