using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Test.Core.Interfaces;
using Test.Core.Models;

namespace Test.UserExt.Repositories
{
    [Export(typeof(IUserRepository))]
	[PartCreationPolicy(CreationPolicy.NonShared)]
	public class UserRepository : RepositoryBase<User>, IUserRepository
	{
		[ImportingConstructor]
		public UserRepository(UserContext baseDbContext)
			: base(baseDbContext)
		{
		}

        public IEnumerable<User> Search(string searchString)
        {
			IQueryable<User> queryable = table;
			queryable.Where(b => b.FirstName.IndexOf(searchString, 0, StringComparison.InvariantCulture) != -1  || b.LastName.IndexOf(searchString, 0, StringComparison.InvariantCulture) != -1);
			return queryable.Take(int.MaxValue);
		}
    }
}
