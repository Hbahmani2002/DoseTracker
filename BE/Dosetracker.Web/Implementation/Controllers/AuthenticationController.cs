using Cloud.HL7.Api.Contract;
using GT.UI.WebApi.Implementation;
using Microsoft.AspNetCore.Mvc;
using RiseCoreApi.UI.WebApi.Models.Controller;
using System.Linq;

namespace Cloud.HL7.UI.WebApi.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {

        [HttpPost]
        [Route("/Authentication/Token")]
        public RESTServiceResult<string> Token(LoginUIModel model)
        {
            var token = LoginJWTService.GenerateJwtToken(1, "Test");
            return RESTServiceResult.Ok(token);
        }
        [HttpGet]
        [Route("/Authentication/GetTokenFromAPIKEY")]
        public string GetTokenFromAPIKEY(string apiKey)
        {
            return "Giriş Başarılı";
        }

        [HttpGet]
        [Route("/Authentication/Status")]
        public RESTServiceResult<UserTokenModel> Status()
        {
            if (User == null || User.Identities == null)
                return RESTServiceResult.Ok((UserTokenModel)null);
            var identity = User.Identities.FirstOrDefault();
            if (identity == null)
            {
                return RESTServiceResult.Ok((UserTokenModel)null);
            }
            var item = LoginJWTService.GetTokenValues(identity);
            return RESTServiceResult.Ok(item);
        }
    }
}
