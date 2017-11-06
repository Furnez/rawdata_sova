using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace RdPorSub2
{
    class PostsOwner
    {
        [Column("OwnerUserId")]
        private int Oid { get; set; }
        private int Id { get; set; }
        private String OwnerUserDisplayName { get; set; }
        private DateTime OwnerUserCreationDate { get; set; }
        private String PostsOwnerCountry { get; set; }
        private String PostsOwnerCity { get; set; }
        private int OwnerUserAge { get; set; }
    }
}
