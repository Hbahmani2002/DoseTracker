using Dosetracker.Repository;
using GT.SERVICE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dosetracker.Data.Service
{
    public class TestDataService : BaseService
    {
        DosectrackerRepository _DosectrackerRepository;
        public TestDataService() : base()
        {
            _DosectrackerRepository = new DosectrackerRepository(Workspace);
        }

        public List<string> GetList()
        {
            return _DosectrackerRepository.Query().Select(o => o.Hospitalid).ToList();
        }
    }
}
