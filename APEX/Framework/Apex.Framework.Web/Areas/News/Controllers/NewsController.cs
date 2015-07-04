using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Apex.Framework.Web.Areas.News.Controllers
{
    public class NewsController : Controller
    {
        // GET: News/News
        public ActionResult Index()
        {
            return View();
        }
    }
}