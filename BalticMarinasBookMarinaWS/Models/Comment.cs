using System;

namespace BalticMarinasBookMarinaWS.Models
{
    public class Comment
    {
        private int CommentId { get; set; }
        private string UserName { get; set; }
        private DateTime TimePlaced { get; set; }
        private string Body { get; set; }
        private int MarinaId { get; set; }
    }
}
