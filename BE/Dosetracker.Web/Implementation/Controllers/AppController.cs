using Cloud.HL7.Api.Contract;
using GT.Core.Settings;
using GT.UI.WebApi.Implementation;
using Microsoft.AspNetCore.Mvc;
using RiseCore.Common;
using System;
using System.IO;
using System.Reflection;

namespace Cloud.HL7.UI.WebApi.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class AppController : ControllerBase
    {

        [Route("/App/Control")]
        public RESTServiceResult<object> Control()
        {           
            var ass = Assembly.GetExecutingAssembly().GetName();
            return RESTServiceResult<object>.Ok(new
            {
                AssemblyName = ass.FullName,
                Version = ass.Version.ToString(),
                Settings = AppSettings.GetCurrent(),
                Environment = new
                {
                    CurrentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff"),
                    CurrentDirectory = Environment.CurrentDirectory,
                    MachineName = Environment.MachineName,
                    WorkingSet = Environment.WorkingSet,
                }
            });
        }       
    }
}
