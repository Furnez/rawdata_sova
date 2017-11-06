using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace API
{
    public class PostsOwner
    {
        [Column("OwnerUserId")]
        public int Oid { get; set; }
        public int Id { get; set; }
        public String OwnerUserDisplayName { get; set; }
        public DateTime OwnerUserCreationDate { get; set; }
        public String PostsOwnerCountry { get; set; }
        public String PostsOwnerCity { get; set; }
        public int OwnerUserAge { get; set; }
    }
}
