using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using API.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API
{
    [Route("api/[controller]")]
    public class searchHistoryController : Controller
    {

        private SOVAContext db = new SOVAContext();

        // GET: api/values
        [HttpGet]
        public List<SearchHistory> Get()
        {
            var searchHistory = this.db.searchhistory.ToList<SearchHistory>();

            return searchHistory;
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var searchHistory = db.searchhistory.Find(id);
            if (searchHistory == null)
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return Json(searchHistory);
            }
            Response.StatusCode = (int)HttpStatusCode.OK;
            return Json(searchHistory);
        }

        // POST api/values
        [HttpPost]
        public SearchHistory Post([FromBody]string value)
        {
            SearchHistory searchHistory = new SearchHistory();
            searchHistory = db.searchhistory.Add(searchHistory).Entity;
            db.SaveChanges();
            return searchHistory;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public SearchHistory Put(int id,
                          [FromBody]String SearchString,
                          [FromBody]DateTime SearchDate
                         )
        {
            SearchHistory searchHistory = db.searchhistory.Find(id);
            if (searchHistory == null)
                return null;
            else
            {
                searchHistory.SearchString = SearchString;
                searchHistory.SearchDate = SearchDate;
            }
            return searchHistory;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public SearchHistory Delete(int id)
        {
            SearchHistory searchHistory = db.searchhistory.Find(id);
            if (searchHistory == null) return null;
            else
            {
                db.searchhistory.Remove(searchHistory);
                db.SaveChanges();
            }
            return searchHistory;
        }
    }
}
