using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DangNgocDuc
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {


            routes.MapRoute(
                name: "DanhSach_",
                url: "danh-sach-thanh-vien",
                defaults: new { controller = "DangNgocDuc", action = "DanhSach" },
                namespaces: new string[]
                {"DangNgocDuc.Controllers"}
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "DangNgocDuc", action = "Index", id = UrlParameter.Optional }
            );



        }
    }
}
