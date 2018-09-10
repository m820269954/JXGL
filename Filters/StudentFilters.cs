using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace jxgl.Filters
{
    public class StudentFilters:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["UserGroup"].ToString() != "Student")
            {
                filterContext.Result = new ContentResult()
                {
                    Content = "访问未经授权内容！"
                };
            }
        }
    }
}