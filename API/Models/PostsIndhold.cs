﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace API
{
    public class PostsIndhold
    {
        [Column("Id")]
        public int Id { get; set; }
        public int PostTypeId { get; set; }
        public int OwneruserId { get; set; }
        public System.Nullable<int> ParentId { get; set; }
        public System.Nullable<int> AcceptedAnswerId { get; set; }
        public DateTime CreationDate { get; set; }
        public int Score { get; set; }
        public String Body { get; set; }
        public System.Nullable<DateTime> ClosedDate { get; set; }
        public String Title { get; set; }
    }
}
