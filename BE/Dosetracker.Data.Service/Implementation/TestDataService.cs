using Dosetracker.Data.Service.Conditions;
using Dosetracker.Repository;
using GT.SERVICE;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Dosetracker.Data.Service
{
    public class DoseTracerDataService : BaseService
    {

        DosectrackerRepository _DosectrackerRepository;
        public DoseTracerDataService() : base()
        {
            _DosectrackerRepository = new DosectrackerRepository(Workspace);
        }

        public List<List<double>> GetList(DateTime? start, DateTime? end, long[] hospitalIDList, string groupBy = "age")
        {
            var exp = DoseTrackerCondition.Exp(start, end, hospitalIDList);

            var table = _DosectrackerRepository.Query(exp);
            IQueryable<IGrouping<int?, Persistance.Domain.Models.Dosetracker>> qGrouped = null;
            if (true) // groupBy=="age"
            {
                qGrouped = table.GroupBy(o => o.Patientage);

            }

            var res = qGrouped.Select(o => new
            {
                Age = o.Key,
                Min = o.Min(t => t.Studysar),
                Max = o.Max(t => t.Studysar),
                Avg = o.Average(t => t.Studysar)
            });
            var list = res.ToList();
            var data = list
                .Select(o => new List<double> {
                    o.Age.GetValueOrDefault(),
                    o.Min.GetValueOrDefault(),
                    o.Max.GetValueOrDefault(),
                    o.Avg.GetValueOrDefault(),
                    o.Avg.GetValueOrDefault(),
                }
                ).ToList();
            return data;

        }
    }
}
