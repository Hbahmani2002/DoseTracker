using GT.SERVICE;
using GT.UI.WebApi.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Cloud.HL7.UI.WebApi.Controller
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class AuthenticatedBaseController : ControllerBase
    {
        public UserTokenModel UserToken
        {
            get
            {
                var identity = User.Identities.FirstOrDefault();
                if (identity == null)
                {
                    throw new ApplicationException("Yetkisiz Kullanıcı");
                }
                var item = LoginJWTService.GetTokenValues(identity);
                return item;
            }
        }
        IBussinessContext _bussinessContext;
        public IBussinessContext BussinesContext
        {
            get
            {
                if (_bussinessContext == null)
                {

                    var id = UserToken.ID;
                    var cxModel = new UserContextModel(id);
                    _bussinessContext = new BussinessContext(cxModel);
                }
                return _bussinessContext;
            }
        }
    }
}
