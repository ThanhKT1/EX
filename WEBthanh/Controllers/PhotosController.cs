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
    public class PhotosController : Controller
    {
        // GET: Photos
        WEBTHANHEntities2 db = new WEBTHANHEntities2();
        public PartialViewResult PhotosPartial(int? page)
        {
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return PartialView(db.HinhAnhPhotos.ToList().ToPagedList( pageNumber,pageSize));
        }
        public ActionResult XemChiTiet(int MaHA)
        {
            HinhAnhPhoto photos = db.HinhAnhPhotos.SingleOrDefault(n => n.MaHA == MaHA);
            if (photos == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(photos);
        }

    }
}