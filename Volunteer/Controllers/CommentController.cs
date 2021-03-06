using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL;
using Entity;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Volunteer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {

        ICommentBL commentbl;

        public CommentController(ICommentBL commentbl)
        {
            this.commentbl = commentbl;

        }
        // GET api/<CommentController>/5
        [HttpGet]
        public async Task<List<Comment>> getComments()
        {
            return await commentbl.getComments();
        }
        // GET api/<CommentController>/5
        [HttpGet("{id}")]
        public async Task<Comment> getCommentById(int id)
        {
            return await commentbl.getCommentById(id);
        }
        //post
        [HttpPost]
        public async Task<int> postComment([FromBody ] Comment cmt)
        {
            return await commentbl.postComment(cmt);
        }
        // PUT api/<CommentController>/5
        [HttpPut]
        public async Task<Comment> putComment([FromBody] Comment cmt)
        {
            return await commentbl.putComment(cmt);
        }
        // DELETE api/<CommentController>/5
        [HttpDelete("{id}")]
        public async Task deleteComment(int id)
        {

            await commentbl.deleteComment(id);
        }

        //comments from students
        //get
        //[HttpGet]
        //public async Task<List<StudentComment>> getStudentComments()
        //{
        //    return await ;
        //}
    }
}

