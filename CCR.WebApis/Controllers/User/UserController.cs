using CCR.WebApis.Service.Business.User;
using CCR.WebApis.Service.DtoModel.User;
using CCR.WebApis.Service.Interface.User;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCR.WebApis.Controllers.User
{
    public class UserController : ApiControllerBase
    {
        private readonly IUserBusiness _userBusiness;
        public UserController(UserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        [HttpGet]
        public ActionResult<UserInfoResult> GetUserInfo()
        {
            var user = new UserInfoResult();
            return user;
        }

        [HttpGet("{id}")]
        public ActionResult<UserInfoResult> GetUserInfo(int id)
        {
            var user = _userBusiness.GetUserInfo(id);
            if (user == null)
                return NotFound();

            return user;
        }
    }
}
