using BalticMarinasBookMarinaWS.Models;
using System.Collections.Generic;

namespace BalticMarinasBookMarinaWS.Repositories.Interfaces
{
    interface ICommentRepository
    {
        void CreateComment(Comment comment);
        List<Comment> GetAllCommentByMarinaId(int marinaId);
    }
}
