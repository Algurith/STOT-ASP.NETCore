using CCR.WebApis.Service.DtoModel.User;
using CCR.WebApis.Service.Interface.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCR.WebApis.Service.Business.User
{
    public class UserBusiness : IUserBusiness
    {
        public UserInfoResult GetUserInfo(int id)
        {
            var users = new List<Tuple<int, string>>
            {
                new Tuple<int, string>(1, "one"),
                new Tuple<int, string>(2, "two"),
                new Tuple<int, string>(3, "three"),
            };

            var user = users.FirstOrDefault(t => t.Item1 == id);
            return user == null ? null : new UserInfoResult
            {
                Id = user.Item1,
                Name = user.Item2
            };
        }
    }
}
