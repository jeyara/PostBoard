using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PostBoard.Controllers
{
	public class HomeController : Controller
	{
		//
		// GET: /Home/
		public ActionResult Index()
		{
			return View();
		}

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Stream()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}