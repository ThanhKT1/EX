using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBthanh.Models;

namespace WEBthanh.Controllers
{
    public class NguoiDungADController : Controller
    {
        // GET: NguoiDungAD
        WEBTHANHEntities2 db = new WEBTHANHEntities2();
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(NGUOIDUNGAD nguoidungad)
        {
            if (ModelState.IsValid)
            {
                db.NGUOIDUNGADs.Add(nguoidungad);
                db.SaveChanges();
                ViewBag.ThongBao = "Đăng ký thành công";
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

            NGUOIDUNGAD nguoidungad = db.NGUOIDUNGADs.SingleOrDefault(n => n.TaiKhoan == sTaiKhoan && n.MatKhau == sMatKhau);

            if(nguoidungad != null)
            {
                Session["TaiKhoan"] = nguoidungad;
                return RedirectToAction("Index", "Admin");
            }
            ViewBag.ThongBao = "Sai tài khoản hoặc mật khẩu";
            return View();
        }
    }
}