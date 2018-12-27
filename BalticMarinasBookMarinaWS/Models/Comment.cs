using System;

namespace BalticMarinasBookMarinaWS.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string UserName { get; set; }
        public DateTime TimePlaced { get; set; }
        public string Body { get; set; }
        public int MarinaId { get; set; }
    }
}
