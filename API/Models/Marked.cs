using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace API
{
    public class Marked
    {
        [Column("Markedid")]

        public int Mid { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public int CommentsId { get; set; }
        public int Id { get; set; }
        public String MarkedString { get; set; }
        public DateTime MarkedCreationDate { get; set; }
    }
}
