using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace jxgl.Models
{
    public class CS
    {

        public int? Score { get; set; }
        [Key]
        [Column(Order =1)]

        public string Sno { get; set; }
        [Key]
        [Column(Order = 2)]
        public string Cno { get; set; } 
    }

}