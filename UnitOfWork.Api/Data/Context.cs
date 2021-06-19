using Microsoft.EntityFrameworkCore;
using UnitOfWork.Api.Models;

namespace UnitOfWork.Api.Data
{
    public class Context : DbContext
    {
        public DbSet<Person> Person { get; set; }
        public Context(DbContextOptions contextOptions) : base(contextOptions)
        {
        }

    }
}
