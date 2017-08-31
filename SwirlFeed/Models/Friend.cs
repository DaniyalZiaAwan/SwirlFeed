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
            return new List<Post>(User1Id == myId ?
                                   User2.Posts : User1.Posts);
        }
    }
}