using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CCR.WebApis.Controllers
{
    /// <summary>
    /// 使用[ApiController]属性的控制器基类
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ApiControllerBase : ControllerBase
    {
        
    }
}