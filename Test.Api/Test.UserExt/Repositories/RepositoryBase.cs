using System;
using System.Data.Entity;
using System.Threading.Tasks;
using Test.Core.Interfaces;
using Test.Core.Models;

namespace Test.UserExt.Repositories
{
	public abstract class RepositoryBase<T> : IGenericRepository<T> where T : BaseEntity
	{
		protected readonly DbContext context;
		protected readonly DbSet<T> table;

		protected RepositoryBase(UserContext baseDbContext)
		{
			context = baseDbContext;
			table = baseDbContext.Set<T>();
		}

        public T Create(T entity)
        {
			if (entity == null)
			{
				throw new ArgumentNullException(nameof(entity));
			}

			var entityExist = table.Find(entity.Id);

			if (entityExist != null)
			{
				throw new ArgumentException(@"Entity with that Id already exists", nameof(entity));
			}

			var result = table.Add(entity);
			context.SaveChanges();
			return result;
		}

        public T Delete(int id)
        {
            var entity = table.Find(id);

			if (entity == null)
			{
				throw new ArgumentException(@"No entity with that Id", nameof(id));
			}

			table.Remove(entity);
			context.SaveChanges();
			return entity;
		}

        public async Task<T> GetAsync(int id)
        {
			return await table.FindAsync(id);
		}

        public T Update(T entity)
        {
			var entityExist = table.Find(entity.Id);

			if (entityExist == null)
			{
				throw new ArgumentException(@"No entity with that Id ", nameof(entity));
			}

			context.Entry(entityExist).CurrentValues.SetValues(entity);
			context.SaveChanges();
			return entity;
        }
    }
}
