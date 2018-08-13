using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBthanh.Models;
using PagedList;
using PagedList.Mvc;
using System.IO;

namespace WEBthanh.Controllers
{
    public class AdminController : Controller
    {

        // GET: Admin
        WEBTHANHEntities2 db = new WEBTHANHEntities2();

        public ActionResult Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(db.TrichhDoans.ToList().ToPagedList(pageNumber,pageSize));
        }
      
        //Thêm sản phẩm
        //THÊM mới dữ lie6u5
        [HttpGet]
        public ActionResult ThemMoi()
        {
            //Đưa dữ liệu vào dropdownlist
            return View();
        }
        //Upload ảnh
        [HttpPost]

        [ValidateInput(false)]//Phải có cái này, k là nó k chạy, khi chèn thẻ html vào code

        public ActionResult ThemMoi(TrichhDoan trichdoan, HttpPostedFileBase fileUpload)
        {

            //Đưa dữ liệu vào dropdownlist

            //Kiểm tra đường dẫn Ảnhn
            if (fileUpload == null)
            {
                ViewBag.ThongBao = "Chọn hình ảnh";
                return View();
            }

            //Thêm vào CSDL
            //kiểm tra valuedation
            if (ModelState.IsValid)//Nếu nó thỏa mãn tất cả cả đk của các cái control ta đã nhập vào
            {
                //Lưu tên của file
                var fileName = Path.GetFileName(fileUpload.FileName);//để lấy cái tên của nó r lưu vô csld
                                                                     //Lưu đường dẫn của file
                var path = Path.Combine(Server.MapPath("~/HinhAnhTrichDoan/"), fileName);//truyền 2 tham số: đường dẫn tới hình ảnh VÀ fileName
                                                                                  //Kiểm tra nếu hình ảnh này nếu tồn tại r dựa vào cái tên thì mình sẽ k cho nó lưu vào, chưa tồn tại thì lưu
                if (System.IO.File.Exists(path))
                {
                    ViewBag.ThongBao = "Hình ảnh đã tồn tại";
                }
                else
                {
                    fileUpload.SaveAs(path);
                }

                trichdoan.Anh = fileUpload.FileName;

                // db.MENUs.Add(menu);
                db.TrichhDoans.Add(trichdoan);
                db.SaveChanges();

            }
            return View();
        }
        //CHỈNH SỬA SẢN PHÂMmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm
        [HttpGet]
        public ActionResult ChinhSua(int MaTD)
        {
            //Lấy ra đối tượng menu theo mã
            TrichhDoan trichdoan = db.TrichhDoans.SingleOrDefault(n => n.MaTD == MaTD);
            if (trichdoan == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(trichdoan);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ChinhSua(TrichhDoan trichdoan, FormCollection f)
        {

            //Thêm vào csdl
            if (ModelState.IsValid)
            {
                //Thực hiện cập nhật trong model
                db.Entry(trichdoan).State = System.Data.Entity.EntityState.Modified;//Nó lấy cái biến "menu" nó thực hiện những cái thay đổi đó ở trong Model, r ta SAVECHANGE nó sẽ update lại db 
                db.SaveChanges();
            }
            //Đưa dữ liệu vào dropdownlist
   

            return View(trichdoan);

        }

        //HIỂN THỊIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII
        public ActionResult ChiTiet(int MaTD)
        {
            //Lấy ra đối tượng menu theo mã
            TrichhDoan trichdoan= db.TrichhDoans.SingleOrDefault(n => n.MaTD == MaTD);
            if (trichdoan == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(trichdoan);
        }

        //XÓA SẢN PHẨMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM
        [HttpGet]
        public ActionResult Xoa(int MaTD)
        {
            //Lấy ra đối tượng menu theo mã
            TrichhDoan trichdoan= db.TrichhDoans.SingleOrDefault(n => n.MaTD == MaTD);
            if (trichdoan == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(trichdoan);
        }
        [HttpPost, ActionName("Xoa")]
        public ActionResult XacNhanXoa(int MaTD)
        {
            //Lấy ra đối tượng menu theo mã
            TrichhDoan trichdoan = db.TrichhDoans.SingleOrDefault(n => n.MaTD == MaTD);
            if (trichdoan == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            db.TrichhDoans.Remove(trichdoan);
            return RedirectToAction("Index","Admin");
        }

    }
}