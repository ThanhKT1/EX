using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBthanh.Models;

namespace WEBthanh.Controllers
{
    public class NguoiDungController : Controller
    {
        // GET: NguoiDung
        WEBTHANHEntities2 db = new WEBTHANHEntities2();
        [HttpGet]
        public ActionResult SignOut()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignOut(NGUOIDUNG kh)
        {
            if (ModelState.IsValid)
            {
                db.NGUOIDUNGs.Add(kh);
                db.SaveChanges();
            }
            return View();
        }



        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            string sTaiKhoan = f["txtTaiKhoan"].ToString();
            string sMatKhau = f["txtMatKhau"].ToString();

            NGUOIDUNG kh = db.NGUOIDUNGs.SingleOrDefault(n => n.TaiKhoan == sTaiKhoan && n.MatKhau == sMatKhau);
            if (kh != null)
            {
                ViewBag.ThongBao = "Đăng nhập thành công";
                Session["TaiKhoan"] = kh;
                return RedirectToAction("Index", "Home");
            }
            ViewBag.ThongBao = "Sai tài khoản hoặc mật khẩu";
            return View();

        }

    }
}