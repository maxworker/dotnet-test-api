using System.Threading.Tasks;
using Test.Core.Models;

namespace Test.Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetAsync(int id);

        T Delete(int id);

        T Update(T entity);

        T Create(T entity);
    }
}
