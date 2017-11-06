using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace RdPorSub2
{
    class SearchHistory
    {
        [Column("SearchNumberId")]
        private int Id { get; set; }
        private String SearchString { get; set; }
        private DateTime SearchDate { get; set; }
    }
}
