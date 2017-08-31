using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SwirlFeed.Models;
using SwirlFeed.Repositories;
using SwirlFeed.ViewModels;

namespace SwirlFeed.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public HomeController()
        {
            _unitOfWork = new UnitOfWork(new ApplicationDbContext());
        }

        [Authorize]
        public ActionResult Index()
        {
            var myId = User.Identity.GetUserId();
            var myFriends = _unitOfWork.FriendRepository
                                       .GetAllWithRelatedData(myId);

            var posts = _unitOfWork.FriendRepository
                                   .GetFriendsPosts(myId, myFriends);

            var viewModel = new HomeIndexVm
            {
                User = _unitOfWork.UserRepository.GetWithRelatedData(myId),
                Posts = posts.OrderByDescending(p => p.Id).ToList()
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