using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFramework;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class NotesController : Controller
    {

        private SOVAContext db = new SOVAContext();

        // GET: api/values
        [HttpGet]
        public List<PersonalNotes> Get()
        {
            var notes = this.db.personalnotes.ToList<PersonalNotes>;

            return notes;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public PersonalNotes Get(int id)
        {
            var note = this.db.personalnotes.Include(x => x.PersonalNotes).FirstOrDefault(x => x.Id == id);

            return note;
        }

        // POST api/values
        [HttpPost]
        public PersonalNotes Put(String new_note, DateTime note_date)
        {
            PersonalNotes createNote = new PersonalNotes { NoteString = new_note, NoteCreationDate = note_date};
            return createNote;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public bool UpdateNote(int id, string new_notestring)
        {
            PersonalNotes personalID = db.personalnotes.Find(x => x.Id == id);
            if (personalID == null){
                return false;
            } else {
                personalID.NoteString = new_notestring;
                db.SaveChanges();
            }
            return true;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            PersonalNotes noteId = db.personalnotes.Find(x => x.Id == id);
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
