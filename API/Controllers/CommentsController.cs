using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class CommentsController : Controller
    {
        private SOVAContext db = new SOVAContext();

        // GET: api/values
        [HttpGet]
        public List<Commentsbody> Get()
        {
            var comments = this.db.commentsbody.ToList<Commentsbody>();

            return comments;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var comment = db.commentsbody.Find(id);
            if (comment == null)
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return Json(comment);
            }
            Response.StatusCode = (int)HttpStatusCode.OK;
            return Json(comment);
        }

        // POST api/values
        [HttpPost]
        public Commentsbody Post([FromBody]string value)
        {
            Commentsbody comment = new Commentsbody();
            comment = db.commentsbody.Add(comment).Entity;
            db.SaveChanges();
            return comment;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public Commentsbody Put(int id, [FromBody]DateTime commentcreatedate, [FromBody]string commenttext)
            
        {
            Commentsbody commentsbody = db.commentsbody.Find(id);
            if (commentsbody == null)
                return null;
            else
            {
                commentsbody.Commentcreatedate = commentcreatedate;
                commentsbody.Commenttext = commenttext;
            }
            return commentsbody;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public Commentsbody Delete(int id)
        {
            Commentsbody commentsbody = db.commentsbody.Find(id);
            if (commentsbody == null) return null;
            else
            {
                db.commentsbody.Remove(commentsbody);
                db.SaveChanges();
            }
            return commentsbody;
        }
    }
}
