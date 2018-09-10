using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace jxgl.Models
{
    public class Student
    {
        [Key]
        [Display(Name ="学号")]
        [Required(ErrorMessage = "学号必填")]
        [StringLength(maximumLength: 11, MinimumLength = 11, ErrorMessage = "学号长度应为11位请检查")]
        public string Sno { get; set; }
        [Display(Name = "姓名")]
        [Required(ErrorMessage = "姓名必填")]
        public string Sname { get; set; }
        [Display(Name = "性别")]
        [Required(ErrorMessage = "性别必填")]
        public string Ssex { get; set; }
        [Display(Name ="学院")]
        [Required(ErrorMessage = "学院必填")]
        public string Sacad { get; set; }
        public string Spwd { get; set; }
    }

}