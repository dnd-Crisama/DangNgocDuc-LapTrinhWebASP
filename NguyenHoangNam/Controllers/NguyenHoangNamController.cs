using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NguyenHoangNam.Controllers
{
    public class NguyenHoangNamController : Controller
    {
        // GET: NguyenHoangNam
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NavPartial()
        {
            return PartialView();
        }
        public ActionResult ChuDePartial()
        {
            return PartialView();
        }
        public ActionResult NhaXuatBanPartial()
        {
            return PartialView();
        }
        public ActionResult FoodterPartial()
        {
            return PartialView();
        }
    }
}