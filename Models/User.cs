using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
namespace jxgl.Models
{
    public class User
    {
       [Key]
       [Required(ErrorMessage ="name为必填属性")]
       [StringLength(maximumLength:16,MinimumLength =6,ErrorMessage ="用户名最长16位，最短6位")]
       [Display(Name ="用户名")]
        public string username { get; set; }
        [Required(ErrorMessage ="PassWord为必填属性")]
        [Display(Name ="密码")]
        [StringLength(maximumLength:16,MinimumLength =6)]
        [RegularExpression("^(?![a-zA-z]+$)(?!\\d+$)(?![!@#$%^&*]+$)[a-zA-Z\\d!@#$%^&*]+$", ErrorMessage ="密码必须包含数字字母的组合，且为6-16位")]
        public string userpwd { get; set; }
    }
    public class UserDBContext : DbContext
    {
       public DbSet<User> Users { get; set; }
    }
}