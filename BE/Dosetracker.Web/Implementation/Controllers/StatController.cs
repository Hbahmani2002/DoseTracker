﻿using Cloud.HL7.Api.Contract;
using Dosetracker.Data.Service;
using Dosetracker.Repository.Models;
using GT.Core.Settings;
using GT.UI.WebApi.Implementation;
using Microsoft.AspNetCore.Mvc;
using RiseCore.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using static Dosetracker.Data.Service.DoseTracerDataService;

namespace Cloud.HL7.UI.WebApi.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class StatController : ControllerBase
    {
        public class SarGroupDataFilter
        {                                
            public long[] HospitalIDList { get; set; }
            
            public DateTime? DateStart { get; set; }
            public DateTime? DateEnd { get; set; }
            public GroupType Group { get; set; }
        }

        [Route("/Stat/GetSarGroupData")]
        [HttpPost]
        public RESTServiceResult<STATUIModel> GetSarGroupData(SarGroupDataFilter filter)
        {
            var service = new DoseTracerDataService();
            var data = service.GetList(filter.DateStart, filter.DateEnd, filter.HospitalIDList, filter.Group);
            return RESTServiceResult.OkData(data);
        }

        [Route("/Stat/GetDataOzet")]
        [HttpPost]
        public RESTServiceResult<DataOzetViewModel> GetDataOzet(SarGroupDataFilter filter)
        {
            var service = new DoseTracerDataService();
            var data = service.GetDataOzet(filter.DateStart, filter.DateEnd, filter.HospitalIDList, filter.Group);
            return RESTServiceResult.OkData(data);
        }
    }
}
