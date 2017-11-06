using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace RdPorSub2
{
    class Commentsbody
    {
        [Column("Commentid")]

        private int Id { get; set; }
        private int Postid { get; set; }
        private int Commentscore { get; set; }
        private String Commenttext { get; set; }
        private DateTime Commentcreatedate { get; set; }
        private int Userid { get; set; }

        //public virtual Commentsbody Commentsbody { get; set; }
        
    }
}
