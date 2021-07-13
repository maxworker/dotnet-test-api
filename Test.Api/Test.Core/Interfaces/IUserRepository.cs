using System.Collections.Generic;
using Test.Core.Models;

namespace Test.Core.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        IEnumerable<User> Search(string searchString);
    }
}
