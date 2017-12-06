using System;
using System.Dynamic;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using API.Models;

namespace API.Controllers
{
    public class PostsController : Controller
    {
        private SOVAContext db = new SOVAContext();

        // GET api/posts
        [Route("api/[controller]")]
        [HttpGet]
        public ActionResult GetAll()
        {
            var posts = this.db.postsindhold.Where(x => x.PostTypeId == 1).ToList<PostsIndhold>();
            if (posts.Count == 0)
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return Json(posts);
            }

            Response.StatusCode = (int)HttpStatusCode.OK;
            return Json(posts);
        }

        // GET api/posts/5
        [Route("api/[controller]/{id}")]
        [HttpGet]
        public ActionResult GetById(int id)
        {
            dynamic post_info = new ExpandoObject();
            List<Commentsbody> comments = new List<Commentsbody>();

            post_info.posts = this.db.postsindhold.Where(x => x.Id == id || x.ParentId == id).ToList<PostsIndhold>();

            foreach(PostsIndhold post in post_info.posts) {
                var result_comments = this.db.commentsbody.Where(y => y.Postid == post.Id).ToList<Commentsbody>();
                comments.AddRange(result_comments);
            }
            post_info.comments = comments;

            if (post_info.posts.Count == 0 && post_info.comments.Count == 0) {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return Json(post_info);
            }

            Response.StatusCode = (int)HttpStatusCode.OK;
            return Json(post_info);
        }

        // GET api/posts/marked
        /**
            Get every marked posts
         */
        [Route("api/[controller]/marked")]
        [HttpGet]
        public ActionResult GetMarked()
        {
            var marked_posts = this.db.postsindhold.Join(this.db.marked, x => x.Id, y => y.PostId, (x, y) => x).ToList();
            if (marked_posts.Count == 0) {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return Json(null);
            }

            Response.StatusCode = (int)HttpStatusCode.OK;
            return Json(marked_posts);
        }

        // GET api/posts/search/entity_framework
        [Route("api/[controller]/search/{search}")]
        [HttpGet]
        public ActionResult GetPostsBySearch(string search)
        {
            var posts = db.postsindhold.Where(p => p.Body.Contains(search));

            if (posts.ToList().Count > 0)
                return Json(posts);

            Response.StatusCode = (int)HttpStatusCode.NotFound;
            return Json(posts);
        }

        // POST api/posts
        [Route("api/[controller]")]
        [HttpPost]
        public ActionResult Post([FromBody]string new_post)
        {
            dynamic Objectpost = JsonConvert.DeserializeObject(new_post);

            Objectpost = this.db.postsindhold.Add(Objectpost).Entity;
            db.SaveChanges();

            Response.StatusCode = (int)HttpStatusCode.Created;
            return Json(Objectpost);
        }

        // PUT api/posts/5
        [Route("api/[controller]/{id}")]
        [HttpPut]
        public ActionResult Put(int id, [FromBody]string post_to_update)
        {
            dynamic Objectpost = JsonConvert.DeserializeObject(post_to_update);
            PostsIndhold postsIndhold = db.postsindhold.Find(id);
            if (postsIndhold == null)
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return Json(null);
            }

            Response.StatusCode = (int)HttpStatusCode.OK;
            return Json(postsIndhold);
        }

        // DELETE api/posts/5
        [Route("api/[controller]/{id}")]
        [HttpDelete]
        public void Delete(int id)
        {
            PostsIndhold postsIndhold = db.postsindhold.Find(id);
            if (postsIndhold == null)
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return;
            }
            db.postsindhold.Remove(postsIndhold);
            db.SaveChanges();

            Response.StatusCode = (int)HttpStatusCode.OK;
        }
    }
}