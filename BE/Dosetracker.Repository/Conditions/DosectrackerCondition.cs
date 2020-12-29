using DBLayerIzcilikYonetimi.Moduller.IzciYonetimi;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Dosetracker.Repository.Condition
{
    public class DosectrackerCondition
    {
        public class DosectrackerConditionFilter
        {
            public DateTime? BasTar { get; set; }
            public DateTime? BitTar { get; set; }
            public bool? IsRiskli { get; set; }
        }
        public static Expression<Func<Dosetracker.Persistance.Domain.Models.Dosetracker, bool>> Get(DosectrackerConditionFilter filter)
        {
            var exp = PredicateBuilder.True<Dosetracker.Persistance.Domain.Models.Dosetracker>();
            if (filter.BasTar.HasValue)
            {
                exp = exp.And(o => o.Studydate >= filter.BasTar.Value);
            }
            if (filter.BitTar.HasValue)
            {
                exp = exp.And(o => o.Studydate <= filter.BitTar.Value);
            }
            if (filter.IsRiskli.HasValue)
            {
                exp = exp.And(o => o.Studysar > 3.2);
            }
            return exp;
        }
    }
}
