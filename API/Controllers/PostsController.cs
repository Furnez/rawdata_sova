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
    
    public class PostsController : Controller
    {
        private SOVAContext db = new SOVAContext();

        // GET api/values
        [Route("api/[controller]")]
        [HttpGet]
        public List<PostsIndhold> Get()
        {
            var posts = this.db.postsindhold.ToList<PostsIndhold>();

            return posts;
        }


        // GET api/values/5
        [Route("api/[controller]/{id}")]
        [HttpGet]
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
        [Route("api/[controller]/new")]
        [HttpPost]
        public PostsIndhold Post([FromBody]string value)
        {
            PostsIndhold post = new PostsIndhold();
            post = db.postsindhold.Add(post).Entity;
            db.SaveChanges();
            return post;
        }

        // PUT api/values/5
        [Route("api/[controller]/up/{id}")]
        [HttpPut]
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
        [Route("api/[controller]/del/{id}")]
        [HttpDelete]
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

        [Route("api/[controller]/search/{search}")]
        [HttpGet]
        public ActionResult GetPostsBySearch(string search)
        {
            var posts = db.postsindhold.Where(p => p.Body.Contains(search));

            if (posts.ToList().Count > 0)
                return Json(posts);
            else
                Response.StatusCode = (int)HttpStatusCode.NotFound;
            return Json(posts);
        }
    }
}
