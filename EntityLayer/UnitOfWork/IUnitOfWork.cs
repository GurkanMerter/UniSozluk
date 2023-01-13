using System.Threading.Tasks;

namespace EntityLayer.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task CommitAsync(); 
        void Commit(); 
    }
}
