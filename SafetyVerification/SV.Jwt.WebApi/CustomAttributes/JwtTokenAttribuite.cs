using JWT;
using JWT.Serializers;
using SV.Jwt.WebApi.Models.Dto;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace SV.Jwt.WebApi.CustomAttributes
{
    public class JwtTokenAttribute : AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            var header = from t in actionContext.Request.Headers
                         where t.Key == "auth"
                         select t.Value.FirstOrDefault();

            if (header == null)
                return false;

            var token = header.FirstOrDefault();
            if (string.IsNullOrEmpty(token))
                return false;
            try
            {
                const string secret = "Technology has changed life";
                var serializer = new JsonNetSerializer();
                var provider = new UtcDateTimeProvider();
                var validator = new JwtValidator(serializer, provider);
                var urlEncoder = new JwtBase64UrlEncoder();
                var decoder = new JwtDecoder(serializer, validator, urlEncoder);

                var json = decoder.DecodeToObject<AuthInfo>(token, secret, verify: true);
                if (json != null)
                {
                    actionContext.RequestContext.RouteData.Values.Add("auth", json);

                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}