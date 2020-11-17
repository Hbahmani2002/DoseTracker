using Gt.PERSISTANCE;
using RiseCore.PERSISTANCE;
using System;

namespace GT.SERVICE
{
    public abstract class BaseService : IDisposable
    {
        protected AbstractWorkspace Workspace { get; }
        protected IBussinessContext Context { get; }
        public BaseService(IBussinessContext context, AbstractWorkspace workspace)
        {
            Context = context;
            Workspace = workspace;
        }
        protected BaseService(IBussinessContext context, bool log = false)
        {
            Context = context;
            Workspace = WorkspaceFactory.Create(log);
        }
        public BaseService()
        {
            Workspace = WorkspaceFactory.Create(false);
        }
        protected void Commit()
        {
            Workspace.CommitChanges();
        }
        public void Dispose()
        {
            if (Workspace == null)
                return;
            Workspace.Dispose();
        }
    }
}