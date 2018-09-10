using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jxgl.ViewModel
{
    public class CSViewModel
    {
        public CSViewModel(){
            this.Ccredit = null;
            this.Cname = null;
            this.Cno = null;
            this.Ctime = null;
            this.Ctrem = null;
            this.Checked = false;
            this.Tname = null;
            this.Score = null;
            this.Tno = null;
        }
        public string Cno { get; set; }
        public string Cname { get; set; }
        public string Tno { get; set; }
        public string Tname { get; set; }
        public string Ctrem { get; set; }
        public string Ctime { get; set; }
        public string Ccredit { get; set; }
        public bool Checked{ get; set; }
        public int? Score { get; set; }
    }
    public class CSListViewModel
    {
        public List<CSViewModel> CSs { get; set; }
    }
}