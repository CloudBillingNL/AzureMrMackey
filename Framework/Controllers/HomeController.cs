using System;
using System.Security.Cryptography;
using System.Web.Mvc;

namespace AzureMrMackey.Framework.Controllers
{
    public class HomeController : Controller
    {
        private RandomNumberGenerator rng = RandomNumberGenerator.Create();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MrMackey(int size = 0)
        {
            var bytes = new byte[size];
            rng.GetBytes(bytes);
            var random = Convert.ToBase64String(bytes).Substring(0, size);
            Response.Headers["X-MrMackey"] = random;
            return new ContentResult();
        }
    }
}
