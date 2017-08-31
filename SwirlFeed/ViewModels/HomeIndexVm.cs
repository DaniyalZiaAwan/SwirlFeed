using System.Collections.Generic;
using SwirlFeed.Models;

namespace SwirlFeed.ViewModels
{
    public class HomeIndexVm
    {
        public ApplicationUser User { get; set; }
        public Post Post { get; set; }
        public List<Post> Posts { get; set; }
    }
}