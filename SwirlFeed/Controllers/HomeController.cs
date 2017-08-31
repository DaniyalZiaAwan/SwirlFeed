using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SwirlFeed.Repositories;
using SwirlFeed.ViewModels;

namespace SwirlFeed.Controllers
{
    public class HomeController : Controller
    {
        readonly IUnitOfWork _unitOfWork;
        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Authorize]
        public ActionResult Index()
        {
            var myId = User.Identity.GetUserId();

            var myFriends = _unitOfWork.FriendRepository
                                       .GetAllWithRelatedData(myId);

            // getting posts of ur friends
            var posts = _unitOfWork.FriendRepository
                                   .GetFriendsPosts(myId, myFriends);

            // adding ur posts
            var me = _unitOfWork.UserRepository.Get(myId);
            posts.AddRange(me.Posts);

            var viewModel = new HomeIndexVm
            {
                User = _unitOfWork.UserRepository.GetWithRelatedData(myId),
                Posts = posts.OrderByDescending(p => p.Id).ToList()
            };

            return View(viewModel);
        }
    }
}