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
        public class STATUIModel
        {
            public string[] XLabels { get; set; }
            public string YLabel { get; set; }
            public string Title { get; set; }
            public object[][] SerieData { get; set; }
        }
        public enum GroupType
        {
            Sex = 1,
            Age = 2,
            Weight = 3,
            BMI = 4,
            AgeRange = 5,
        }
        class SerieItem
        {
            public object Key { get; set; }

            public double? Min { get; set; }
            public double? Max { get; set; }
            public double? Avg { get; set; }
        }

        public STATUIModel GetList(DateTime? start, DateTime? end, long[] hospitalIDList, GroupType group)
        {
            var item = new STATUIModel();
            item.YLabel = "SAR";
            IQueryable<IGrouping<string, Persistance.Domain.Models.Dosetracker>> qGrouped = null;
            IQueryable<IGrouping<double, Persistance.Domain.Models.Dosetracker>> qGroupedDouble = null;
            var exp = DoseTrackerCondition.Exp(start, end, hospitalIDList);
            var table = _DosectrackerRepository.Query(exp);
            if (group == GroupType.Age)
            {
                qGroupedDouble = table.GroupBy(o => (double)o.Patientage.Value);
                item.Title = "Yaşa Göre SAR";
                item.YLabel = "SAR";
            }
            else if (group == GroupType.Sex)
            {
                qGrouped = table.GroupBy(o => o.Patientsex.Value.ToString());
                item.Title = "Cinsiyete Göre SAR";

                item.XLabels = new string[] { "kadın", "erkek" };
            }
            else if (group == GroupType.Weight)
            {
                qGroupedDouble = table.GroupBy(o => (double)o.Patientweight.Value);
                item.Title = "Weight Göre SAR";

            }
            else if (group == GroupType.BMI)
            {
                item.XLabels = new string[] {"<18,5","18,5-25","25-30","30-40","40<"};
                qGroupedDouble = table.GroupBy(o => o.Vucutkitleendeksi<=(18.5)? (double)0 : ((o.Vucutkitleendeksi>18.5 && o.Vucutkitleendeksi<=25)? (double)1 :
                ((o.Vucutkitleendeksi>25 && o.Vucutkitleendeksi<=30)? (double)2 :((o.Vucutkitleendeksi>30 && o.Vucutkitleendeksi<=40)? (double)3 : (double)4))));
                item.Title = "BMI Göre SAR";
            }
            else if (group == GroupType.AgeRange)
            {
                var labels = new List<string>();
                for (int i = 0; i < 15; i++)
                {
                    var labelItem = ((i + 1) * 10) + "-" + ((i + 2) * 10);
                    labels.Add(labelItem);
                }
                item.XLabels = labels.ToArray();
                qGroupedDouble = table.GroupBy(o => (double)((int)o.Studysar / 10));
                item.Title = "Yaş aralığına Göre SAR";

            }
            IQueryable<SerieItem> res = null;
            if (qGroupedDouble != null)
            {
                res = qGroupedDouble.Select(o => new SerieItem
                {
                    Key = o.Key,
                    Min = o.Min(t => t.Studysar),
                    Max = o.Max(t => t.Studysar),
                    Avg = o.Average(t => t.Studysar)
                });
            }
            else
            {
                res = qGrouped.Select(o => new SerieItem
                {
                    Key = o.Key,
                    Min = o.Min(t => t.Studysar),
                    Max = o.Max(t => t.Studysar),
                    Avg = o.Average(t => t.Studysar)
                });

            }
            var list = res.OrderBy(o => o.Key).ToList();
            var data = list
                    .Select(o => new
                    {
                        Key = o.Key == null ? "tanımlanmamış" : ((item.XLabels != null) ? item.XLabels[Convert.ToInt32(o.Key)] : o.Key),
                        Min = o.Min.GetValueOrDefault(),
                        Avg = o.Avg.GetValueOrDefault(),
                        Max = o.Max.GetValueOrDefault(),
                    }
                    ).ToArray();

            item.SerieData = data
                    .Select(o =>
                        new[] { o.Key, o.Min, o.Avg, o.Max
        }
                        )
                        .ToArray();
            return item;

        }
    }
}
