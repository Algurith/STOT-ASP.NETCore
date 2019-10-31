using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using SV.Jwt.WebApi.Models.Dto;
using SV.Jwt.WebApi.Models.Param;
using SV.Jwt.WebApi.Models.Result;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace SV.Jwt.WebApi.Controllers
{
    public class LoginController : ApiController
    {
        [HttpPost]
        public LoginResult Login(LoginParam param)
        {
            if (string.IsNullOrEmpty(param?.UserName))
                return new LoginResult { Success = false, Message = "请输入用户名!" };

            var userName = "Andervic";
            var psd = "123654";
            if (!userName.Equals(param.UserName) || !psd.Equals(param.Password))
                return new LoginResult { Success = false, Message = "用户名密码错误!" };

            var result = new LoginResult();
            var authInfo = new AuthInfo
            {
                UserName = userName,
                Roles = new List<string> { "Admin", "Manage" },
                IsAdmin = true
            };
            try
            {
                const string secret = "Technology has changed life";

                var algorithm = new HMACSHA256Algorithm();
                var serializer = new JsonNetSerializer();
                var urlEncoder = new JwtBase64UrlEncoder();
                var encoder = new JwtEncoder(algorithm, serializer, urlEncoder);

                var token = encoder.Encode(authInfo, secret);
                result.Message = "赢了!";
                result.Token = token;
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Success = false;
            }

            return result;
        }
    }
}