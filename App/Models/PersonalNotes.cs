using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class PersonalNotes
    {
        [Column("NoteId")]
        public int Nid { get; set; }
        public int UserId { get; set; }
        public System.Nullable<int> PostId { get; set; }
        public System.Nullable<int> CommentsId { get; set; }
        public System.Nullable<int> Id { get; set; }
        public String NoteString { get; set; }
        public DateTime NoteCreationDate { get; set; }
    }
}
