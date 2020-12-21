using System.Runtime.Serialization;
using System.Web.Mvc;
using System.Web.Security;
using DashboardApp.Models;

namespace DashboardApp.Controllers
{
    public class LoginController : Controller
    {
        
        
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Index(string username, string password)
        {
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                FormsAuthentication.SetAuthCookie(username,false);
                return Redirect(FormsAuthentication.GetRedirectUrl(username, false));

            }
            return View();
        }
        
        public ActionResult Login(LoginObj login)
        {
            if (!string.IsNullOrEmpty(login.username) && !string.IsNullOrEmpty(login.password))
            {
                FormsAuthentication.SetAuthCookie(login.username,false);
                return Redirect(FormsAuthentication.GetRedirectUrl(login.username, false));

            }
            return View(login);
        }

        
    }
}