﻿using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StatusBoard.Models.Visual;
using WebMatrix.WebData;

namespace StatusBoard.Controllers
{
    public class VisualController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
        public JsonResult Data()
        {
            var userID = WebSecurity.GetUserId(User.Identity.Name);
            var jsonModel = new DataJsonModel(userID);
            return Json(jsonModel, JsonRequestBehavior.AllowGet);
        }
    }
}
