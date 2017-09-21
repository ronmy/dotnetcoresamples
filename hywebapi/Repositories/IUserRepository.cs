using System.Collections.Generic;
using hywebapi.Models;

namespace hywebapi.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();

        User GetById(int id);
    }
}

