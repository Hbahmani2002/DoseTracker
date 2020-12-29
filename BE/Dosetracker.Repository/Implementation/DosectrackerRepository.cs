using Dosetracker.Repository.Condition;
using GT.REPOSITORY;
using RiseCore.PERSISTANCE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using static Dosetracker.Repository.Condition.DosectrackerCondition;

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

        public IQueryable<Dosetracker.Persistance.Domain.Models.Dosetracker> Query(DosectrackerConditionFilter filter)
        {
            var res = DosectrackerCondition.Get(filter);
            return Query(res);
        }

        public IQueryable<Dosetracker.Persistance.Domain.Models.Dosetracker> Query(Expression<Func<Dosetracker.Persistance.Domain.Models.Dosetracker, bool>> exp)
        {
            var query = Workspace.Query<Dosetracker.Persistance.Domain.Models.Dosetracker>(exp);
            return query;
        }
    }
}
