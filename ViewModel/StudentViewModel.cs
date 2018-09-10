using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jxgl.ViewModel
{
    public class  StudentViewModel
    {
        public string Sno { get; set; }
        public string Sname { get; set; }
        public string Ssex { get; set; }
        public string Sacad { get; set; }
        public string Cno { get; set; }
        public string Cname { get; set; }
        public int? Sscore { get; set; }
    }
    public class StudentListViewModel
    {
     public   List<StudentViewModel> Students { get; set; } 
    }
}