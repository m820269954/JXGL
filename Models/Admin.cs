using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace jxgl.Models
{
    public class Admin
    {
        [Key]
        public string Aname { get; set; }
        public string Apwd { get; set; }
    }
}