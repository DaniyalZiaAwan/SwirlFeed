using System;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SwirlFeed.Models;

namespace SwirlFeed.Controllers
{
    public class PostsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public PostsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public ActionResult Add(Post post)
        {
            var myId = User.Identity.GetUserId();

            post.DateTime = DateTime.Now;
            post.Posted_ById = myId;
            post.User_Closed = false;
            post.User_Deleted = false;

            _context.Posts.Add(post);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}