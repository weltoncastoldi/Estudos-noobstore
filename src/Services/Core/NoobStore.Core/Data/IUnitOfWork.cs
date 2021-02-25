using System.Threading.Tasks;

namespace NoobStore.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}