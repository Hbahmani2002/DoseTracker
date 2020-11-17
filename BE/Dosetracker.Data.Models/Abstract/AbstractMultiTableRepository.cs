using Gt.PERSISTANCE;
using RiseCore.PERSISTANCE;
using System.Linq;

namespace GT.REPOSITORY
{
    public abstract class AbstractMultiTableRepository<T1,T2,T3>: AbstractRepository
    {
        public IQueryable<T1> T1s { get; set; }
        public IQueryable<T2> T2s { get; set; }
        public AbstractMultiTableRepository(IAbstractWorkspace workspace) : base(workspace)
        {
            
        }
        
    }
}