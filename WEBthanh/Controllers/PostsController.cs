using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBthanh.Models;

namespace WEBthanh.Controllers
{
    public class PostsController : Controller
    {
        // GET: Posts
        WEBTHANHEntities2 db = new WEBTHANHEntities2();
        public ActionResult PostsPartial()
        {
            return View(db.BaiVietts.ToList());
        }
        public ActionResult TrichDoan()
        {
            return View(db.TrichhDoans.ToList());
        }
    }
}