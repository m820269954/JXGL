using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
namespace jxgl.Models
{
    public class Course
    {
        [Key]
        [Display(Name ="课序号")]
        [Required(ErrorMessage = "必填")]
        [StringLength(maximumLength: 3, MinimumLength = 3, ErrorMessage = "课程号为3位")]
        public string Cno { get; set; }
        [Required(ErrorMessage = "必填")]
        [Display(Name = "课程名")]
        public string Cname { get; set; }
        [Display(Name ="课时数")]
        [Required(ErrorMessage = "必填")]
        public string Ctime { get; set; }
        [Display(Name ="学期")]
        [Required(ErrorMessage = "必填")]
        public string Ctrem { get; set; }
        [Display(Name ="学分")]
        [Required(ErrorMessage = "必填")]
        public string Ccredit { get; set; }
    }
}