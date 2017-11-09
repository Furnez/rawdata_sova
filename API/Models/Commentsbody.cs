using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace API
{
    public class Commentsbody
    {
        [Column("Commentid")]

        public int Id { get; set; }
        public int Postid { get; set; }
        public int Commentscore { get; set; }
        public String Commenttext { get; set; }
        public DateTime Commentcreatedate { get; set; }
        public int Userid { get; set; }

        //public virtual Commentsbody Commentsbody { get; set; }
        
    }
}
