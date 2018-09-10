using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace jxgl.Models
{
    public class TC
    {
        [Display(Name = "教师号")]
        [Key, Column(Order = 1)]
        public string Tno { get; set; }
        [Display(Name = "课程号")]
        [Key, Column(Order = 2)]
        public string Cno { get; set; }
        [Display(Name = "上课时间（第几大节课）")]
        [Key, Column(Order = 3)]
        public string Time { get; set; }
        [Display(Name = "上课日期（周几）")]
        [Key, Column(Order = 4)]
        public string Day { get; set; }
        [Display(Name = "教学楼")]
        [Key, Column(Order = 5)]
        public string Location { get; set; }
        [Key, Column(Order = 6)]
        [Display(Name = "教室号")]
        public int RoomNum { get; set; }
        [Display(Name = "开始周")]
        public int StarTime { get; set; }
        [Display(Name = "结束周")]
        public int EndTime { get; set; }


    }
}