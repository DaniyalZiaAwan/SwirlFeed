using System.Web.Mvc;

namespace SwirlFeed.Controllers
{
    public class ProfileController : Controller
    {
        public ActionResult UserProfile() => View();
    }
}