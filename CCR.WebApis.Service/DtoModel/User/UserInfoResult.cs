using System;
using System.Collections.Generic;
using System.Text;

namespace CCR.WebApis.Service.DtoModel.User
{
    public class UserInfoResult : BaseResult
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
