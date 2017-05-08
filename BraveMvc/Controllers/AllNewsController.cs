using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BraveMvc.Controllers
{
    public class AllNewsController : Controller
    {
        // GET: AllNews
        public ActionResult Index()
        {
            return View();
        }
    }
}