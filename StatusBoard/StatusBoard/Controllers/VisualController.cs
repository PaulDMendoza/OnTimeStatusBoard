using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using StatusBoard.Filters;
using StatusBoard.Models;
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
            var context = new UsersContext();
            var userProfile = context.UserProfiles.First(u => u.UserId == userID);
            if (string.IsNullOrWhiteSpace(userProfile.OnTimeAuthorizationToken))
            {
                return RedirectToAction("Manage", "Account");
            }

            string key = "IndexViewModel_" + userID + "_" + type;
            var model = this.HttpContext.Cache[key] as IndexViewModel;
            if (model == null)
            {
                model = new IndexViewModel(userID, type);
                this.HttpContext.Cache.Add(key, model, dependencies: null, absoluteExpiration: DateTime.Now.AddSeconds(model.RefreshRate), slidingExpiration: Cache.NoSlidingExpiration, priority: CacheItemPriority.Normal, onRemoveCallback: null);
            }

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
