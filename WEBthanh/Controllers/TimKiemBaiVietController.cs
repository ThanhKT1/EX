using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBthanh.Models;
using PagedList;
using PagedList.Mvc;

namespace WEBthanh.Controllers
{
    public class TimKiemBaiVietController : Controller
    {
        // GET: TimKiemBaiViet
        WEBTHANHEntities2 db = new WEBTHANHEntities2();
        [HttpPost]
        public ActionResult KetQuaTimKiem(FormCollection f,int? page)
        {
            string sTuKhoa = f["txtfindphotos"].ToString();
            ViewBag.TuKhoa = sTuKhoa;
            List<HinhAnhPhoto> lstPhotos = db.HinhAnhPhotos.Where(n => n.DiaDiem.Contains(sTuKhoa)).ToList();

            int pageSize = 6;
            int pageNumber = (page ?? 1);
            if (lstPhotos.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy sản phẩm cần tìm";
                return View(db.HinhAnhPhotos.ToList().ToPagedList(pageNumber,pageSize));
            }
            ViewBag.ThongBao = "Đã tìm thấy " + lstPhotos.Count + "sản phẩm";
            return View(lstPhotos.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult KetQuaTimKiem(string sTuKhoa,int? page)
        {
            ViewBag.TuKhoa = sTuKhoa;
            List<HinhAnhPhoto> lstPhotos = db.HinhAnhPhotos.Where(n => n.Anh.Contains(sTuKhoa)).ToList();

            int pageSize = 6;
            int pageNumber = (page ?? 1);
            if (lstPhotos.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy sản phẩm cần tìm";
                return View(db.HinhAnhPhotos.ToList().ToPagedList(pageNumber, pageSize));
            }
            ViewBag.ThongBao = "Đã tìm thấy " + lstPhotos.Count + "sản phẩm";
            return View(lstPhotos.ToPagedList(pageNumber, pageSize));
        }
    }
}