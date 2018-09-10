using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
namespace jxgl.Models
{
    public class Teacher
    {
        [Display(Name ="教师号")]
        [Key]
        [StringLength(maximumLength:7,MinimumLength =7,ErrorMessage ="教师号为7位")]
        [Required(ErrorMessage ="必填")]
        public string Tno { get; set; }
        [Display(Name ="教师名")]
        [Required(ErrorMessage = "必填")]
        public string Tname{ get; set; }
        [Display(Name ="性别")]
        [Required(ErrorMessage = "必填")]
        public string Tsex { get; set; }
        [Display(Name ="学院")]
        [Required(ErrorMessage = "必填")]
        public string Tacad { get; set; }
        [Display(Name ="密码")]
        [Required(ErrorMessage = "必填")]
        public string Tpwd { get; set; }

    }

}