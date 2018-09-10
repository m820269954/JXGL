using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jxgl.ViewModel
{
    public class TCViewModel
    {
        public string Cno { get; set; }
        public string Cname { get; set; }
        public string Time { get; set; }
        public string Day { get; set; }
        public string Location { get; set; }
        public int RoomNum { get; set; }
        public int StarTime { get; set; }
        public int EndTime { get; set; }
        public int ChoosedNum { get; set; }
    }
}