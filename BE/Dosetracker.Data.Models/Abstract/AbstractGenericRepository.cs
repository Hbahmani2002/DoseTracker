using Gt.PERSISTANCE;
using RiseCore.PERSISTANCE;

namespace GT.REPOSITORY
{
    public abstract class AbstractRepository
    {
        private IAbstractWorkspace _Workspace;
        public AbstractRepository(IAbstractWorkspace workspace)
        {
            _Workspace = workspace;
        }

        protected IAbstractWorkspace Workspace { get => _Workspace; }
    }
}