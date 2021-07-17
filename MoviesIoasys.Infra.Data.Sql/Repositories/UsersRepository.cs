using Microsoft.EntityFrameworkCore;
using MoviesIoasys.Domain.Entities;
using MoviesIoasys.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoviesIoasys.Infra.Data.Sql.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly DataContext _context;
        private readonly DbSet<User> _users;

        public UsersRepository(
            DataContext context
        )
        {
            _context = context;
            _users = _context.Set<User>();
        }

        public IEnumerable<User> GetAllNotAdmAndActive(int page = 0, int size = 5)
        {
            var users = _users.AsNoTracking().Where(user => user.Active
                                                                    && user.UserRole != Domain.Enums.UserRole.Admin)
                                                                    .OrderBy(user => user.Name);

            if (page > 0)
                return users.Skip((page - 1) * size).Take(size);

            return users;
        }

        public User GetUserByEmail(string email)
            => _users.AsNoTracking().FirstOrDefault(user => user.Email == email);

        public User GetUserById(Guid id)
            => _users.AsNoTracking().FirstOrDefault(user => user.Id == id);

        public User Save(User user)
        {
            _users.Add(user);
            _context.SaveChanges();

            return user;
        }

        public User Update(User user)
        {
            _users.Attach(user);
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();

            return user;
        }
    }
}
