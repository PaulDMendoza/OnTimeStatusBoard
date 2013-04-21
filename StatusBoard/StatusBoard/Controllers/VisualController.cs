using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StatusBoard.Filters;
using StatusBoard.Models.Visual;
using WebMatrix.WebData;

namespace StatusBoard.Controllers
{
    [InitializeSimpleMembership]
    public class VisualController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            var userID = WebSecurity.GetUserId(User.Identity.Name);
            var model = new IndexViewModel(userID);

            return View(model);
        }

        public JsonResult Data()
        {
            var userID = WebSecurity.GetUserId(User.Identity.Name);
            var jsonModel = new DataJsonModel(userID);
            return Json(jsonModel, JsonRequestBehavior.AllowGet);
        }

        public ActionResult TypeScriptInterfaces()
        {
            this.Response.ContentType = "text/plain";
            return View();
        }
    }
}
