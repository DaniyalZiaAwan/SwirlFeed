using System;

namespace SwirlFeed.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public DateTime DateTime { get; set; }
        public bool User_Closed { get; set; }
        public bool User_Deleted { get; set; }

        public ApplicationUser Posted_By { get; set; }
        public ApplicationUser User_To { get; set; }
    }
}