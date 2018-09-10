using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Data.Entity;
using jxgl.Data_Access_Layer;
namespace jxgl
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Database.SetInitializer(new MvcMusicStore.Models.SampleData());
            //当提供了初始化数据时，使用该形式，以初始化数据库策略并填充一些数据当某个Model改变了，就删除原来的数据库创建新的数据库）
            Database.SetInitializer<JXGLDBContext>(new DropCreateDatabaseIfModelChanges<JXGLDBContext>());
            //没提供数据库初始化数据时使用该形式
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
