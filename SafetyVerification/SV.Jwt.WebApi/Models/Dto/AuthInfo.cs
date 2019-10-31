using System.Collections.Generic;

namespace SV.Jwt.WebApi.Models.Dto
{
    public class AuthInfo
    {
        /// <summary>
        /// 模拟JWT的PayLoad
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Roles
        /// </summary>
        public List<string> Roles { get; set; }

        /// <summary>
        /// 是否管理员
        /// </summary>
        public bool IsAdmin { get; set; }
    }
}