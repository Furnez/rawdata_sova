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
    public class CommentUserController : Controller
    {
        private SOVAContext db = new SOVAContext();

        // GET: api/values
        [HttpGet]
        public List<CommentUser> Get()
        {
            var CUsers = this.db.commentuser.ToList<CommentUser>();

            return CUsers;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var CUser = db.commentuser.Find(id);
            if (CUser == null)
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return Json(CUser);
            }
            Response.StatusCode = (int)HttpStatusCode.OK;
            return Json(CUser);
        }

        // POST api/values
        [HttpPost]
        public CommentUser Post([FromBody]string value)
        {
            CommentUser CUser = new CommentUser();
            CUser = db.commentuser.Add(CUser).Entity;
            db.SaveChanges();
            return CUser;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public CommentUser Put(int id, [FromBody]String UserName, 
                                       [FromBody]DateTime UserCreationDate,
                                       [FromBody]int UserAge)
        {
            CommentUser CUser = db.commentuser.Find(id);
            if (CUser == null)
                return null;
            else
            {
                CUser.UserDisplayname = UserName;
                CUser.UserCreationDate = UserCreationDate;
            }
            return CUser;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public CommentUser Delete(int id)
        {
            CommentUser CUser = db.commentuser.Find(id);
            if (CUser == null) return null;
            else
            {
                db.commentuser.Remove(CUser);
                db.SaveChanges();
            }
            return CUser;
        }
    }
}
