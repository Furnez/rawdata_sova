using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class PostsLinkpostId
    {
        [Column("Id")]
        public int Id { get; set; }
        public int LinkpostId { get; set; }
        public int OwnerUserId { get; set; }
    }
}
