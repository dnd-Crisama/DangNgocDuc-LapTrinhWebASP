using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DangNgocDuc.Models
{
    public class PaginationViewModel
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public IEnumerable<DangNgocDuc.Models.SACH> Data { get; set; }
    }
}