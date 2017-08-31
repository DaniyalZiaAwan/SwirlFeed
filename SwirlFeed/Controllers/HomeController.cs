using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SwirlFeed.Models;
using SwirlFeed.ViewModels;

namespace SwirlFeed.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Index()
        {
            var myId = User.Identity.GetUserId();
            var me = _context.Users.Find(myId);

            var viewModel = new HomeIndexVm

            {
                User = me,
                Posts = _context.Posts.OrderByDescending(p => p.Id).ToList()
            };

            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}