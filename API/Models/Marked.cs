using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace RdPorSub2
{
    class Marked
    {
        [Column("Markedid")]

        private int Mid { get; set; }
        private int UserId { get; set; }
        private int PostId { get; set; }
        private int CommentsId { get; set; }
        private int Id { get; set; }
        private String MarkedString { get; set; }
        private DateTime MarkedCreationDate { get; set; }
    }
}
