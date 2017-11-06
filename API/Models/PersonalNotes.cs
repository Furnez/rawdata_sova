using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace API
{
    public class PersonalNotes
    {
        [Column("NoteId")]
        public int Nid { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public int CommentsId { get; set; }
        public int Id { get; set; }
        public String NoteString { get; set; }
        public DateTime NoteCreationDate { get; set; }
    }
}
