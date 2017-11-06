using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace RdPorSub2
{
    class CommentUser
    {
        [Column("userid")]

        private int Id { get; set; }
        private String UserDisplayname { get; set; }
        private int UserAge { get; set; }
        private String UserLocationCountry { get; set; }
        private String UserLocationCity { get; set; }
        private DateTime UserCreationDate { get; set; }
    }
}
