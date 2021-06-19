using System.Threading.Tasks;

namespace UnitOfWork.Api.Data
{

    public interface IUnitOfWork
    {
        Task<bool> CommitAsync();
        void RoolBack();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context context;

        public UnitOfWork(Context context) => this.context = context;

        public async Task<bool> CommitAsync() => await context.SaveChangesAsync() > 0;

        public void RoolBack() => context.Dispose();
    }
}
