using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Dosetracker.Data.Service.Conditions
{
    public class DoseTrackerCondition
    {
        public static Expression<Func<Persistance.Domain.Models.Dosetracker, bool>> Exp(DateTime? start, DateTime? end, long[] hospitalIDList)
        {
            var exp = PredicateBuilder.New<Persistance.Domain.Models.Dosetracker>(true);
            if (start.HasValue)
            {
                //exp= exp.And(o=>o.
            }
            return exp;
        }
    }
}
