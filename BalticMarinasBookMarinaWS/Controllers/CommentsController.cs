using BalticMarinasBookMarinaWS.Models;
using BalticMarinasBookMarinaWS.Repositories;
using BalticMarinasBookMarinaWS.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BalticMarinasBookMarinaWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        // GET api/marinas/1/comments
        [HttpGet("marinas/{marinaId}/comments")]
        public IEnumerable<Comment> GetAllCommentsByMarinaId(int marinaId)
        {
            ICommentRepository repository = HttpContext.RequestServices.GetService(typeof(CommentRepository)) as CommentRepository;
            return repository.GetAllCommentsByMarinaId(marinaId);
        }

        // POST api/comments
        [HttpPost]
        public void Post([FromBody] Comment comment)
        {
            ICommentRepository repository = HttpContext.RequestServices.GetService(typeof(CommentRepository)) as CommentRepository;
            repository.CreateComment(comment);
        }
    }
}