using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace RdPorSub2
{
    class PostsIndhold
    {
        [Column("Id")]
        private int Id { get; set; }
        private int PostTypeId { get; set; }
        private int OwneruserId { get; set; }
        private int ParentId { get; set; }
        private int AcceptedAnswerId { get; set; }
        private DateTime CreationDate { get; set; }
        private int Score { get; set; }
        private String Body { get; set; }
        private DateTime ClosedDate { get; set; }
        private String Title { get; set; }
    }
}
