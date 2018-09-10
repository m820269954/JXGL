using jxgl.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using jxgl.Filters;
using jxgl.Models;
using jxgl.Data_Access_Layer;
namespace jxgl.Controllers
{
    public class CSController : Controller
    {
        [Authorize]
        // GET: CS
        [StudentFilters]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        [StudentFilters]
        public ActionResult ClassList()
        {
            JXGLBusinessLayer businessLayer = new JXGLBusinessLayer();
            List<CSViewModel> list = new List<CSViewModel>();
            CSListViewModel CSList = new CSListViewModel();
            CSList.CSs = businessLayer.GetCS(this.HttpContext.Session["UserName"].ToString());
            return View("ClassList",CSList);
        }
        [Authorize]
        [StudentFilters]
        public ActionResult Chooselesson()
        {
            JXGLBusinessLayer businessLayer = new JXGLBusinessLayer();
            List<CSViewModel> list = new List<CSViewModel>();
            CSListViewModel SCList = new CSListViewModel();
            SCList.CSs = businessLayer.GetSC(this.HttpContext.Session["UserName"].ToString());
            return View("Chooselesson", SCList);
        }
        [HttpPost]
        [Authorize]
        [StudentFilters]
        public string DoChooseLesson(List<string> Cnos)
        {
            try {
            JXGLDBContext context = new JXGLDBContext();
            for(int i = 0; i < Cnos.Count; i++)
                {
                    CS cs = new CS();
                    cs.Sno = this.HttpContext.Session["UserName"].ToString();
                    cs.Cno = Cnos[i];
                    context.CSs.Add(cs);
                    context.SaveChanges();
                }
            return "success";
            }
            catch
            {
            return "error";
            }
        }
    }
}