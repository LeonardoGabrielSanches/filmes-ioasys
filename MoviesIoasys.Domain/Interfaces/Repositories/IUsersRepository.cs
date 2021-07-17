using MoviesIoasys.Domain.Entities;
using System;
using System.Collections.Generic;

namespace MoviesIoasys.Domain.Interfaces.Repositories
{
    public interface IUsersRepository
    {
        User Save(User user);
        User GetUserByEmail(string email);
        User GetUserById(Guid id);
        User Update(User user);
        IEnumerable<User> GetAllNotAdmAndActive(int page, int size);
    }
}
