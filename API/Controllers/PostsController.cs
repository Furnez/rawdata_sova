using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Http;


namespace API.Controllers
{
    [Route("api/[controller]")]
    public class PostsController : Controller
    {
        private SOVAContext db = new SOVAContext();

        // GET api/values
        [HttpGet]
        public List<dynamic> Get()
        {
            var posts = this.db.postsindhold.ToList<dynamic>();

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
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
