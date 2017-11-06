﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace API
{
    public class CommentUser
    {
        [Column("userid")]

        public int Id { get; set; }
        public String UserDisplayname { get; set; }
        public int UserAge { get; set; }
        public String UserLocationCountry { get; set; }
        public String UserLocationCity { get; set; }
        public DateTime UserCreationDate { get; set; }
    }
}
