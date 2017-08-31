using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwirlFeed.Models
{
    public class Friend
    {
        public ApplicationUser User1 { get; set; }

        public ApplicationUser User2 { get; set; }

        [Key, Column(Order = 1)]
        public string User1Id { get; set; }

        [Key, Column(Order = 2)]
        public string User2Id { get; set; }

        internal List<Post> AddPostsToUser(string myId)
        {
            var posts = new List<Post>();

            if (User1Id == myId)
                posts.AddRange(User2.Posts);
            else
                posts.AddRange(User1.Posts);

            return posts;
        }
    }
}