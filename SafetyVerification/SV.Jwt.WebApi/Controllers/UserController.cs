using SV.Jwt.WebApi.CustomAttributes;
using SV.Jwt.WebApi.Models.Dto;
using System.Web.Http;

namespace SV.Jwt.WebApi.Controllers
{
    public class UserController : ApiController
    {
        [JwtToken]
        public string Get()
        {
            var info = RequestContext.RouteData.Values["auth"] as AuthInfo;
            if (info == null)
                return "获取不到，失败!";

            return $"获取到了, Auth的Name是{info.UserName}";
        }
    }
}