using System.Security.Claims;

namespace Cloud.HL7.UI.WebApi.Controller
{
    public class UserTokenModel
    {
        public UserTokenModel()
        {
        }

        public string UserName { get; set; }
        public long ID { get; set; }
    }
}