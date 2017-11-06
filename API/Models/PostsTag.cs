using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace RdPorSub2
{
    class PostsTag
    {
        [Column("Id")]
        private int Id { get; set; }
        private String Tag1 { get; set; }
        private String Tag2 { get; set; }
        private String Tag3 { get; set; }
        private String Tag4 { get; set; }
        private String Tag5 { get; set; }
    }
}
