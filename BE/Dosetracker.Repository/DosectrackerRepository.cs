using GT.REPOSITORY;
using RiseCore.PERSISTANCE;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dosetracker.Repository
{
    public class DosectrackerRepository : AbstractTableRepository<Dosetracker.Persistance.Domain.Models.Dosetracker>
    {
        public DosectrackerRepository(IAbstractWorkspace workspace) : base(workspace)
        {

        }
        public override Persistance.Domain.Models.Dosetracker GetByID(long id)
        {
            throw new NotImplementedException();
        }
    }
}
