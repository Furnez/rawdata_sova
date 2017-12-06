using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    public class NotesController : Controller
    {

        private SOVAContext db = new SOVAContext();

        // GET: api/notes
        [Route("api/[controller]")]
        [HttpGet]
        public ActionResult Get()
        {
            var notes = this.db.personalnotes.ToList<PersonalNotes>();

            Response.StatusCode = (int)HttpStatusCode.OK;
            return Json(notes);
        }

        // GET api/notes/5
        [Route("api/[controller]/{id}")]
        [HttpGet]
        public ActionResult Get(int id)
        {
            var note = this.db.personalnotes.Find(id);

            if (note == null){
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return Json(note);
            }
            Response.StatusCode = (int)HttpStatusCode.OK;
            return Json(note);
        }

        // POST api/notes
        [Route("api/[controller]")]
        [HttpPost]
        public PersonalNotes Put(String new_note, DateTime note_date)
        {
            PersonalNotes createNote = new PersonalNotes { NoteString = new_note, NoteCreationDate = note_date};
            
            return createNote;
        }

        // PUT api/notes/5
        [Route("api/[controller]/{id}")]
        [HttpPut]
        public bool UpdateNote(int id, string new_notestring)
        {
            PersonalNotes personalID = db.personalnotes.Find(id);
            if (personalID == null){
                return false;
            } else {
                personalID.NoteString = new_notestring;
                db.SaveChanges();
            }
            return true;
        }

        // DELETE api/values/5
        [Route("api/[controller]/{id}")]
        [HttpDelete]
        public bool Delete(int id)
        {
            PersonalNotes noteId = db.personalnotes.Find(id);
            if (noteId == null) return false;
            else 
            {
                db.personalnotes.Remove(noteId);
                db.SaveChanges();
            }
            return true;
        }
    }
}
