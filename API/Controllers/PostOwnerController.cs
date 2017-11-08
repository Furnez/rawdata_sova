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
    public class PostOwnerController : Controller
    {
        private SOVAContext db = new SOVAContext();

        // GET: api/values
        [HttpGet]
        public List<PostsOwner> Get()
        {
            var owners = this.db.postsowner.ToList<PostsOwner>();

            return owners;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var owner = db.postsowner.Find(id);
            if (owner == null)
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return Json(owner);
            }
            Response.StatusCode = (int)HttpStatusCode.OK;
            return Json(owner);
        }

        // POST api/values
        [HttpPost]
        public PostsOwner Post([FromBody]string value)
        {
            PostsOwner owner = new PostsOwner();
            owner = db.postsowner.Add(owner).Entity;
            db.SaveChanges();
            return owner;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public PostsOwner Put(int id, [FromBody]String OwnerName, [FromBody]DateTime OUserCreationDate)
        {
            PostsOwner owner = db.postsowner.Find(id);
            if (owner == null)
                return null;
            else
            {
                owner.OwnerUserDisplayName = OwnerName;
                owner.OwnerUserCreationDate = OUserCreationDate;
            }
            return owner;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public PostsOwner Delete(int id)
        {
            PostsOwner owner = db.postsowner.Find(id);
            if (owner == null) return null;
            else
            {
                db.postsowner.Remove(owner);
                db.SaveChanges();
            }
            return owner;
        }
    }
}
