using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class PostsTag
    {
        [Column("Id")]
        public int Id { get; set; }
        public String Tag1 { get; set; }
        public String Tag2 { get; set; }
        public String Tag3 { get; set; }
        public String Tag4 { get; set; }
        public String Tag5 { get; set; }
    }
}
