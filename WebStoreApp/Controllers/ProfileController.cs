using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DashboardApp.Controllers
{
    public class ProfileController : Controller
    {

        [Route("profile/{username}")]
        public ActionResult Viewprofile(string username)
        {
            ViewData["name"] = username;
            return View("profile");
        }
    }
}
