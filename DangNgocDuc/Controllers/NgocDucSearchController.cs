using DangNgocDuc.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DangNgocDuc.Controllers
{
    public class NgocDucSearchController : Controller
    {
        SachOnlineEntities db = new SachOnlineEntities();
        // GET: Search
        public ActionResult Search(string strSearch ,int ?page)
        {
            ViewBag.Search = strSearch;
            var chuDeList = db.CHUDEs.ToList();
            ViewBag.cd = chuDeList;
            if (!string.IsNullOrEmpty(strSearch))
            {
                var kq = db.SACHes.Where(s=>s.TenSach.ToLower().Contains(strSearch.ToLower())).ToList();
                int pageSize = 6;
                int pageNumber = (page ?? 1);

                var sachList = kq.ToPagedList(pageNumber, pageSize);

                return View(sachList);
                
            }
            return View();
           
        }

        public ActionResult SearchTheoDanhMuc(string strSearch = null, int maCD = 0, int? page = 1)
        {
            ViewBag.Search = strSearch;

            var kq = db.SACHes.Select(b => b);

            if (!String.IsNullOrEmpty(strSearch))
                kq = kq.Where(b => b.TenSach.Contains(strSearch));

            if (maCD != 0)
            {
                kq = kq.Where(b => b.CHUDE.MaCD == maCD);
            }

            ViewBag.MaCD = new SelectList(db.CHUDEs, "MaCD", "TenChuDe");
            ViewBag.cd = db.CHUDEs.ToList();

            int pageSize = 6;  
            int pageNumber = (page ?? 1);

            var sortedResults = kq.OrderBy(b => b.TenSach);

            var sachListPaged = sortedResults.ToPagedList(pageNumber, pageSize);
            return View("SearchTheoDanhMuc", sachListPaged);
        }
    }
}