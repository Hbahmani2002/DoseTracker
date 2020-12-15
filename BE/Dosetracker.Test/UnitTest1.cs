
//using Dosetracker.Data.Service;
using Dosetracker.Data.Service;
using NUnit.Framework;
using static Dosetracker.Data.Service.DoseTracerDataService;

namespace Dosetracker.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        DoseTracerDataService service = new DoseTracerDataService();
        [Test]
        public void Test1()
        {
            var data = service.GetList(null, null, null, GroupType.Age);
        }
    }
}