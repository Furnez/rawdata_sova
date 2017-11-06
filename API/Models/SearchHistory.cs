using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace API
{
    public class SearchHistory
    {
        [Column("SearchNumberId")]
        public int Id { get; set; }
        public String SearchString { get; set; }
        public DateTime SearchDate { get; set; }
    }
}
