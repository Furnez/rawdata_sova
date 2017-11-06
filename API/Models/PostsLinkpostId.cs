using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace RdPorSub2
{
    class PostsLinkpostId
    {
        [Column("Id")]
        private int Id { get; set; }
        private int LinkpostId { get; set; }
        private int OwnerUserId { get; set; }
    }
}
