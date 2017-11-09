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
        public System.Nullable<int> PostId { get; set; }
        public System.Nullable<int> CommentsId { get; set; }
        public System.Nullable<int> Id { get; set; }
        public String MarkedString { get; set; }
        public DateTime MarkedCreationDate { get; set; }
    }
}
