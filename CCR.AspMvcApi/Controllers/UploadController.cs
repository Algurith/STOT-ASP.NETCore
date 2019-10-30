using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CCR.AspMvcApi.Controllers
{
    public class UploadController : Controller
    {
        // GET: Upload
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult UploadPicture(HttpPostedFileBase httpContext)
        {
            var a = httpContext;

            return Json(new { Success = true, Message = a.FileName });
        }
    }
}