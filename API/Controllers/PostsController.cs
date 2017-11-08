using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class PostsController : Controller
    {
        private SOVAContext db = new SOVAContext();

        // GET api/values
        [HttpGet]
        public List<PostsIndhold> Get()
        {
            var posts = this.db.postsindhold.ToList<PostsIndhold>();

            return posts;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var post = db.postsindhold.Find(id);
            if (post == null){
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return Json(post);
            }
            Response.StatusCode = (int)HttpStatusCode.OK;
            return Json(post);
        }

        // POST api/values
        [HttpPost]
        public PostsIndhold Post([FromBody]string value)
        {
            PostsIndhold post = new PostsIndhold();
            post = db.postsindhold.Add(post).Entity;
            db.SaveChanges();
            return post;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public PostsIndhold Put(int id, [FromBody]string new_title, [FromBody]DateTime closeDate, [FromBody]string body)
        {
            PostsIndhold postsIndhold = db.postsindhold.Find(id);
            if (postsIndhold == null)
                return null;
            else
            {
                postsIndhold.Title = new_title;
                postsIndhold.ClosedDate = closeDate;
                postsIndhold.Body = body;
            }
            return postsIndhold;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public PostsIndhold Delete(int id)
        {
            PostsIndhold postsIndhold = db.postsindhold.Find(id);
            if (postsIndhold == null) return null;
            else
            {
                db.postsindhold.Remove(postsIndhold);
                db.SaveChanges();
            }
            return postsIndhold;
        }
    }
}
