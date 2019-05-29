using CCR.WebApis.Service.DtoModel.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CCR.WebApis.Service.Interface.User
{
    public interface IUserBusiness
    {
        /// <summary>
        /// 获取用户信息
        /// <paramref name="id"/>
        /// </summary>
        UserInfoResult GetUserInfo(int id);
    }
}
