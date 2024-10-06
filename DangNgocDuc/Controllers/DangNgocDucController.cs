﻿    using DangNgocDuc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DangNgocDuc.Models;
using PagedList;
using PagedList.Mvc;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;

namespace DangNgocDuc.Controllers
{
    public class DangNgocDucController : Controller
    {
        // GET: DangNgocDuc
        SachOnlineEntities db = new SachOnlineEntities();
        /* public ActionResult Index()
         {
             var listSachMoi = LaySachMoi(6);
             return View(listSachMoi);
         }*/
        public ActionResult Index(int? page)
        {
            int pageSize = 6;
            int pageNumber = (page ?? 1);

            var sachList = db.SACHes.OrderBy(s => s.MaSach).ToPagedList(pageNumber, pageSize);

            return View(sachList);
        }




        public ActionResult NavPartial()
        {
            return PartialView();
        }
        public ActionResult ChuDePartial()
        {
            var dschude = db.CHUDEs.ToList();
            return PartialView(dschude);
        }
        public ActionResult NhaXuatBanPartial()
        {
            var dsnhaxuatban = db.NHAXUATBANs.ToList();
            return PartialView(dsnhaxuatban);
        }
        public ActionResult FoodterPartial()
        {
            return PartialView();
        }

        public ActionResult SachBanNhieuPartial()
        {
            var listSachBanNhieu = LayBanNhieu(6);
            return PartialView(listSachBanNhieu);
        }

        public ActionResult SliderPartial()
        {
           
            return PartialView();
        }
        public ActionResult ChuDe()
        {
            var dschude = db.CHUDEs.ToList();
            return View(dschude);
        }

        public ActionResult NhaXuatBan()
        {
            var ds = db.NHAXUATBANs.ToList();
            return View(ds);
        }

        private List<SACH> LaySachMoi(int count)
        {  
            return db.SACHes.OrderByDescending(a =>a.NgayCapNhat).Take(count).ToList();
        }
        // GET: SachOnline
        private List<SACH> LayBanNhieu(int count)
        {
            return db.SACHes.OrderByDescending(a => a.SoLuongBan).Take(count).ToList();
        }

        /*blic ActionResult SachTheoChuDe(int id)
        {
            var ds = db.SACHes.Where(sach => sach.MaCD == id).ToList();
            return View(ds);
        }*/
        public ActionResult SachTheoChuDe(int id, int? page)
        {
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            var ds = db.SACHes.Where(sach => sach.MaCD == id).OrderBy(sach => sach.MaSach).ToPagedList(pageNumber, pageSize);

            return View(ds);
        }


        /*blic ActionResult SachTheoNhaXuatBan(int id)
        {
            var ds = db.SACHes.Where(sach => sach.MaNXB == id).ToList();
            return View(ds);
        }*/
        public ActionResult SachTheoNhaXuatBan(int id, int? page)
        {
            int pageSize = 6; 
            int pageNumber = (page ?? 1); 

            var ds = db.SACHes.Where(sach => sach.MaNXB == id).OrderBy(sach => sach.MaSach).ToPagedList(pageNumber, pageSize);

            return View(ds); 
        }


        public ActionResult BookDetail(int id)
        {
            var ds = db.SACHes.Where(sach => sach.MaSach == id).ToList();
            return View(ds);
        }
       
        
    }
}