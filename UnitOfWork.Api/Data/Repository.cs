using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UnitOfWork.Api.Data
{
    public interface IRepository<T> where T : class
    {
        Task<IReadOnlyCollection<T>> GetAllAsync();
        Task AddAsync(T obj);
    }

    public class Repository<T> : IRepository<T> where T : class
    {
        protected Context context;

        public Repository(Context context) => this.context = context;


        public async Task<IReadOnlyCollection<T>> GetAllAsync() => await context.Set<T>().ToListAsync();

        public async Task AddAsync(T obj) => await context.AddAsync(obj);
    }
}
