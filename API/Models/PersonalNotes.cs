using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace RdPorSub2
{
    class PersonalNotes
    {
        [Column("NoteId")]
        private int Nid { get; set; }
        private int UserId { get; set; }
        private int PostId { get; set; }
        private int CommentsId { get; set; }
        private int Id { get; set; }
        private String NoteString { get; set; }
        private DateTime NoteCreationDate { get; set; }
    }
}
