using Dosetracker.Repository;
using Dosetracker.Repository.Models;
using GT.SERVICE;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using static Dosetracker.Repository.Condition.DosectrackerCondition;

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
            PatientSize = 6
        }
        class SerieItem
        {
            public object Key { get; set; }
            public double? Min { get; set; }
            public double? Max { get; set; }
            public double? Avg { get; set; }
            public long DataCount { get; set; }
            public long StudySarCount { get; set; }
            public string[] OperatorList { get; set; }
        }

        public STATUIModel GetList(DateTime? start, DateTime? end, long[] hospitalIDList, GroupType group)
        {
            var item = new STATUIModel();
            item.YLabel = "SAR";
            IQueryable<IGrouping<string, Persistance.Domain.Models.Dosetracker>> qGrouped = null;
            IQueryable<IGrouping<double, Persistance.Domain.Models.Dosetracker>> qGroupedDouble = null;
            var operatorList = new Dictionary<double, string[]>();
            IQueryable<OperatorViewModel> operatorListt = null;
            var filter = new DosectrackerConditionFilter
            {
                BasTar=start,
                BitTar=end
            };
            var table = _DosectrackerRepository.Query(filter);
            if (group == GroupType.Age)
            {
                qGroupedDouble = table.GroupBy(o => (double)o.Patientage.Value);
                item.Title = "Yaşa Göre SAR";
                item.YLabel = "SAR";
                operatorListt= table.Where(o => o.Studysar > 3.2).GroupBy(o => new { PatientAge= (double)o.Patientage.Value ,Operator=o.Operator}).Select(o => new OperatorViewModel
                {
                    Key = o.Key.PatientAge,
                    Operator = o.Key.Operator
                });
                
            }
            else if (group == GroupType.Sex)
            {
                qGroupedDouble = table.GroupBy(o => (double)o.Patientsex.Value);
                item.Title = "Cinsiyete Göre SAR";
                item.XLabels = new string[] { "kadın", "erkek" };
                operatorListt = table.Where(o => o.Studysar > 3.2).GroupBy(o => new { Aralik = (double)o.Patientsex.Value, Operator = o.Operator }).Select(o=> new OperatorViewModel
                { 
                    Key=o.Key.Aralik,
                    Operator=o.Key.Operator
                });
            }
            else if (group == GroupType.Weight)
            {
                qGroupedDouble = table.GroupBy(o => (double)o.Patientweight.Value);
                item.Title = "Weight Göre SAR";
                operatorListt = table.Where(o => o.Studysar > 3.2).GroupBy(o => new { Patientweight = (double)o.Patientweight.Value, Operator = o.Operator }).Select(o => new OperatorViewModel
                {
                    Key = o.Key.Patientweight,
                    Operator = o.Key.Operator
                });
            }
            else if (group == GroupType.BMI)
            {
                item.XLabels = new string[] {"<18,5","18,5-25","25-30","30-40","40<"};
                qGroupedDouble = table.GroupBy(o => o.Vucutkitleendeksi<=(18.5)? (double)0 : ((o.Vucutkitleendeksi>18.5 && o.Vucutkitleendeksi<=25)? (double)1 :
                ((o.Vucutkitleendeksi>25 && o.Vucutkitleendeksi<=30)? (double)2 :((o.Vucutkitleendeksi>30 && o.Vucutkitleendeksi<=40)? (double)3 : (double)4))));
                item.Title = "BMI Göre SAR";
                operatorListt = table.Where(o => o.Studysar > 3.2).GroupBy(o => new
                {
                    BMI = o.Vucutkitleendeksi <= (18.5) ? (double)0 : ((o.Vucutkitleendeksi > 18.5 && o.Vucutkitleendeksi <= 25) ? (double)1 :
                  ((o.Vucutkitleendeksi > 25 && o.Vucutkitleendeksi <= 30) ? (double)2 : ((o.Vucutkitleendeksi > 30 && o.Vucutkitleendeksi <= 40) ? (double)3 : (double)4))),
                    Operator = o.Operator
                }).Select(o => new OperatorViewModel
                {
                    Key = o.Key.BMI,
                    Operator = o.Key.Operator
                });
            }
            else if (group == GroupType.PatientSize)
            {
                item.XLabels = new string[] { "0-10","11-20","21-30","31-40","41-50","51-60","61-70","71-80","81-90","91-100","101-110","111-120","121-130","131-140","141-150","151-..." };
                qGroupedDouble = table.GroupBy(o => o.Patientsize <= 10 ? (double)0 : ((o.Patientsize > 10 && o.Patientsize <= 20) ? (double)1 :
                ((o.Patientsize > 20 && o.Patientsize <= 30) ? (double)2 : ((o.Patientsize > 30 && o.Patientsize <= 40) ? (double)3 : ((o.Patientsize>40 && o.Patientsize<=50)?(double)4:
                ((o.Patientsize>50 && o.Patientsize<=60)?(double)5:((o.Patientsize>60 && o.Patientsize<=70)?(double)6:((o.Patientsize>70 && o.Patientsize<=80)?(double)7:(
                (o.Patientsize>80 && o.Patientsize<=90)?(double)8:((o.Patientsize>90 && o.Patientsize<=100)?(double)9:((o.Patientsize>100 && o.Patientsize<=110)?(double)10:(
                (o.Patientsize>110 && o.Patientsize<=120)?(double)11:((o.Patientsize>120 && o.Patientsize<=130)?(double)12:((o.Patientsize>130 && o.Patientsize<=140)?(double)13:(
                (o.Patientsize>140 && o.Patientsize<=150)?(double)14:(double)15)))))))))))))));

                operatorListt = table.Where(o => o.Studysar > 3.2).GroupBy(o => new
                {
                   Aralik= o.Patientsize <= 10 ? (double)0 : ((o.Patientsize > 10 && o.Patientsize <= 20) ? (double)1 :
                ((o.Patientsize > 20 && o.Patientsize <= 30) ? (double)2 : ((o.Patientsize > 30 && o.Patientsize <= 40) ? (double)3 : ((o.Patientsize > 40 && o.Patientsize <= 50) ? (double)4 :
                ((o.Patientsize > 50 && o.Patientsize <= 60) ? (double)5 : ((o.Patientsize > 60 && o.Patientsize <= 70) ? (double)6 : ((o.Patientsize > 70 && o.Patientsize <= 80) ? (double)7 : (
                (o.Patientsize > 80 && o.Patientsize <= 90) ? (double)8 : ((o.Patientsize > 90 && o.Patientsize <= 100) ? (double)9 : ((o.Patientsize > 100 && o.Patientsize <= 110) ? (double)10 : (
                (o.Patientsize > 110 && o.Patientsize <= 120) ? (double)11 : ((o.Patientsize > 120 && o.Patientsize <= 130) ? (double)12 : ((o.Patientsize > 130 && o.Patientsize <= 140) ? (double)13 : (
                (o.Patientsize > 140 && o.Patientsize <= 150) ? (double)14 : (double)15)))))))))))))),
                Operator=o.Operator
                }).Select(o => new OperatorViewModel
                {
                    Key = o.Key.Aralik,
                    Operator = o.Key.Operator
                });
                item.Title = "Ağırlığa Göre Göre SAR";
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
                qGroupedDouble = table.GroupBy(o => (double)((int)o.Patientage / 10));
                operatorListt = table.Where(o => o.Studysar > 3.2).GroupBy(o => new
                {
                    Aralik = (double)((int)o.Patientage / 10),
                    Operator = o.Operator
                }).Select(o => new OperatorViewModel
                {
                    Key = o.Key.Aralik,
                    Operator = o.Key.Operator
                });
                item.Title = "Yaş aralığına Göre SAR";
            }
            IEnumerable<SerieItem> res = null;
            if (qGroupedDouble != null)
            {
                var keyList = qGroupedDouble.Select(o => o.Key).ToList();
                foreach (var key in keyList)
                {
                    var aa = operatorListt.Where(o => o.Key == key).Select(o => o.Operator).ToArray();
                    operatorList.Add(key, aa);
                }
                res = qGroupedDouble.Select(o => new SerieItem
                {
                    Key = o.Key,
                    Min = o.Min(t => t.Studysar),
                    Max = o.Max(t => t.Studysar),
                    Avg = o.Average(t => t.Studysar),
                    DataCount = o.Count(),
                    StudySarCount = o.Where(x => x.Studysar > 3.2).Count(),
                    OperatorList= operatorList[o.Key]
                });
            }
            else
            {
                res = qGrouped.Select(o => new SerieItem
                {
                    Key = o.Key,
                    Min = o.Min(t => t.Studysar),
                    Max = o.Max(t => t.Studysar),
                    Avg = o.Average(t => t.Studysar),
                    DataCount = o.Count(),
                    StudySarCount = o.Where(x => x.Studysar > 3.2).Count(),
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
                        DataCount = o.DataCount,
                        StudySarCount=o.StudySarCount,
                        OperatorList=o.OperatorList
                    }).ToArray();

            item.SerieData = data
                    .Select(o =>
                        new[] { o.Key, o.Min, o.Avg, o.Max,o.DataCount,o.StudySarCount,o.OperatorList }
                        )
                        .ToArray();
            return item;

        }

        public DataOzetViewModel GetDataOzet(DateTime? start, DateTime? end, long[] hospitalIDList, GroupType group)
        {
            var filter = new DosectrackerConditionFilter
            {
                BasTar = start,
                BitTar = end,
                IsRiskli=true
            };
            var table = _DosectrackerRepository.Query(filter);
            var hastaneList = table.Select(o => o.Hospitalid).ToArray();
            var operatorSayisi = table.Count();

            var filter2 = new DosectrackerConditionFilter
            {
                BasTar = start,
                BitTar = end
            };
            var table2 = _DosectrackerRepository.Query(filter2);
            
            var toplamData = table2.Count();
            var maxSar = string.Format("{0:0.00}", table2.Max(o => o.Studysar)) + " watts/kilogram";
            var minSar = string.Format("{0:0.00}", table2.Min(o => o.Studysar)) + " watts/kilogram";
            return new DataOzetViewModel { 
                HastaneList= hastaneList,
                OperatorSayisi= operatorSayisi,
                ToplamData=toplamData,
                EnDusukSar=minSar,
                EnYuksekSar=maxSar
            };
        }

        public class OperatorViewModel
        {
            public double Key { get; set; }
            public string Operator { get; set; }
        }
    }
}
