using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBthanh.Models;

namespace WEBthanh.Controllers
{
    public class ChiTietTrichDoanController : Controller
    {
        // GET: ChiTietTrichDoan
        WEBTHANHEntities2 db = new WEBTHANHEntities2();
        public ViewResult XemChiTietTD(int MaTD=0)
        {
            TrichhDoan trichdoan = db.TrichhDoans.SingleOrDefault(n => n.MaTD == MaTD);
            if (trichdoan == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(trichdoan);
        }
    }
}