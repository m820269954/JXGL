using jxgl.ViewModel;
using System.Web.Mvc;
using System.Web.Security;
using jxgl.Data_Access_Layer;
namespace jxgl.Controllers
{

    public class AuthorizeController : Controller
    {
        [HttpPost]//登陆
        public string Login(string ume, string pwd)
        {
            JXGLBusinessLayer bal = new JXGLBusinessLayer();
            switch(bal.IsAuth(ume, pwd))
            {
                case "Admin":
                    HttpContext.Session["UserGroup"] = "Admin";
                    HttpContext.Session["UserName"] = ume;
                    return "Admin";
                case "Student":
                    HttpContext.Session["UserGroup"] = "Student";
                    HttpContext.Session["UserName"] = ume;

                    return "Student";
                case "Teacher":
                    HttpContext.Session["UserGroup"] = "Teacher";
                    HttpContext.Session["UserName"] = ume;

                    return "Teacher";
                default:
                    return "error";
            }
        }
        public string Changep(string newpwd)
        {
            JXGLBusinessLayer businessLayer = new JXGLBusinessLayer();
            return businessLayer.ChangePwd(newpwd,this.HttpContext.Session["UserName"].ToString(), this.HttpContext.Session["UserGroup"].ToString());
        }
        public ActionResult Logout()
        {
            
                HttpContext.Request.Cookies.Remove(FormsAuthentication.FormsCookieName);
                FormsAuthentication.SignOut();
                return RedirectToAction("Login", "Home");
          
        }
    }
}