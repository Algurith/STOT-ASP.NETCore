using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace CCR.AspWebApi.Controllers
{
    public class UploadController : ApiController
    {
        [HttpGet]
        public bool Get()
        {
            return true;
        }

        [HttpPost]
        public async Task<Dictionary<string, string>> Post(string imgs = "")
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }
            Dictionary<string, string> dic = new Dictionary<string, string>();
            //string root = HttpContext.Current.Server.MapPath("~/App_Data");//指定要将文件存入的服务器物理位置
            var root = @"F:\GitHub\STOT-ASP.NETCore\CCR.AspWebApi\App_Data";
            var provider = new MultipartFormDataStreamProvider(root);
            try
            {
                // Read the form data.
                await Request.Content.ReadAsMultipartAsync(provider);
                var body = ActionContext.RequestContext;
                var body1 = ControllerContext.RequestContext;
                var body2 = RequestContext;

                // This illustrates how to get the file names.
                foreach (MultipartFileData file in provider.FileData)
                {//接收文件
                    Trace.WriteLine(file.Headers.ContentDisposition.FileName);//获取上传文件实际的文件名
                    Trace.WriteLine("Server file path: " + file.LocalFileName);//获取上传文件在服务上默认的文件名
                }//TODO:这样做直接就将文件存到了指定目录下，暂时不知道如何实现只接收文件数据流但并不保存至服务器的目录下，由开发自行指定如何存储，比如通过服务存到图片服务器
                foreach (var key in provider.FormData.AllKeys)
                {//接收FormData
                    dic.Add(key, provider.FormData[key]);
                }
            }
            catch
            {
                throw;
            }
            return dic;
        }
    }
}
