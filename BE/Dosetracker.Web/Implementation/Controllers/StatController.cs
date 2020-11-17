using Cloud.HL7.Api.Contract;
using Dosetracker.Data.Service;
using GT.Core.Settings;
using GT.UI.WebApi.Implementation;
using Microsoft.AspNetCore.Mvc;
using RiseCore.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Cloud.HL7.UI.WebApi.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class StatController : ControllerBase
    {
        public class SarGroupDataFilter
        {
            public enum GroupType
            {
                Sex = 1,
                Age = 2,
                Weight = 3,
                BMI = 4
            }                                    
            public long[] HospitalIDList { get; set; }
            
            public DateTime? DateStart { get; set; }
            public DateTime? DateEnd { get; set; }
            public GroupType Group { get; set; }
        }

        [Route("/Stat/GetSarGroupData")]
        public RESTServiceResult<List<List<double>>> GetSarGroupData([FromQuery] SarGroupDataFilter filter)
        {
            var service = new DoseTracerDataService();
            var data = service.GetList(filter.DateStart, filter.DateEnd, filter.HospitalIDList);
            return RESTServiceResult.OkData(data);
        }
    }
}
