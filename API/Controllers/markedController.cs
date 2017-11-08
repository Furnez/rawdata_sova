using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API
{
    [Route("api/[controller]")]
    public class markedController : Controller
    {

        private SOVAContext db = new SOVAContext();

        // GET: api/values
        [HttpGet]
        public List<Marked> Get()
        {
            var markedPosts = this.db.marked.ToList<Marked>();

            return markedPosts;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var markedPost = db.marked.Find(id);
            if (markedPost == null)
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return Json(markedPost);
            }
            Response.StatusCode = (int)HttpStatusCode.OK;
            return Json(markedPost);
        }

        // POST api/values
        [HttpPost]
        public Marked Post([FromBody]string value)
        {
            Marked markedPost = new Marked();
            markedPost = db.marked.Add(markedPost).Entity;
            db.SaveChanges();
            return markedPost;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public Marked Put(int id,
                          [FromBody]String MarkedString,
                          [FromBody]DateTime MarkedCreationDate
                         )
        {
            Marked markedPost = db.marked.Find(id);
            if (markedPost == null)
                return null;
            else
            {
                markedPost.MarkedString = MarkedString;
                markedPost.MarkedCreationDate = MarkedCreationDate;
            }
            return markedPost;
        }


        // DELETE api/values/5
        [HttpDelete("{id}")]
        public Marked Delete(int id)
        {
            Marked markedPost = db.marked.Find(id);
            if (markedPost == null) return null;
            else
            {
                db.marked.Remove(markedPost);
                db.SaveChanges();
            }
            return markedPost;
        }
    }
}
