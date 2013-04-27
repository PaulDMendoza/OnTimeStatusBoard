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
        public enum ItemType
        {
            defects,
            features
        }

        [Authorize]
        public ActionResult Index(ItemType? type)
        {
            var userID = WebSecurity.GetUserId(User.Identity.Name);
            var model = new IndexViewModel(userID, type);

            return View(model);
        }
        
        /// <summary>
        /// Generates typescript definition file of OnTime interfaces based on C# mapped types.
        /// </summary>
        /// <returns></returns>
        public ActionResult TypeScriptInterfaces()
        {
            this.Response.ContentType = "text/plain";
            return View();
        }
    }
}
