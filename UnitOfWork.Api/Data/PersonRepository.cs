using UnitOfWork.Api.Models;

namespace UnitOfWork.Api.Data
{
    public interface IPersonRepository : IRepository<Person>
    {
    }

    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(Context context) : base(context)
        {
        }
    }
}
