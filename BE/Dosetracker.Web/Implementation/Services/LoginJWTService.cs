using Cloud.HL7.UI.WebApi.Controller;
using GT.Core.Settings.Global;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace GT.UI.WebApi.Implementation
{
    public class LoginJWTService
    {

        public static string GenerateJwtToken(long ID, string userName)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(GlobalAppSettings.GetCurrent().WebAppSettings.TokenMasterKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, ID.ToString()),
                        new Claim(ClaimTypes.Name, userName)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public static UserTokenModel GetTokenValues(ClaimsIdentity identity)
        {
            //TODO Null check
            //TODO Token Basılma tarihi
            //TODO Son Görülme Tarihi
            var id = identity.Claims.SingleOrDefault(o => o.Type == ClaimTypes.NameIdentifier).Value;
            var userName = identity.Claims.SingleOrDefault(o => o.Type == ClaimTypes.Name).Value;
            return new UserTokenModel() { UserName = userName, ID = long.Parse(id) };
        }

        public static UserTokenModel GetTokenValues(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.ReadToken(token) as JwtSecurityToken;
            var identity = securityToken;

            var id = identity.Claims.SingleOrDefault(o => o.Type == ClaimTypes.NameIdentifier).Value;
            var userName = identity.Claims.SingleOrDefault(o => o.Type == ClaimTypes.Name).Value;

            return new UserTokenModel() { UserName = userName, ID = long.Parse(id) };
        }
    }
}
