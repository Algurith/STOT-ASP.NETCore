using System;
using System.Collections.Generic;
using System.Text;

namespace CCR.WebApis.Service.DtoModel
{
    public class BaseResult
    {
        /// <summary>
        /// 请求结果
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Message { get; set; }
    }
}
