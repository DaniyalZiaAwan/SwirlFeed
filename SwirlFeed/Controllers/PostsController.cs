using System;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SwirlFeed.Models;
using SwirlFeed.Repositories;

namespace SwirlFeed.Controllers
{
    public class PostsController : Controller
    {
        readonly IUnitOfWork _unitOfWork;
        public PostsController()
        {
            _unitOfWork = new UnitOfWork(new ApplicationDbContext());
        }

        [HttpPost]
        public ActionResult Add(Post post)
        {
            var myId = User.Identity.GetUserId();

            post.DateTime = DateTime.Now;
            post.Posted_ById = myId;
            post.User_Closed = false;
            post.User_Deleted = false;

            _unitOfWork.PostRepository.Add(post);
            _unitOfWork.Complete();

            return RedirectToAction("Index", "Home");
        }
    }
}