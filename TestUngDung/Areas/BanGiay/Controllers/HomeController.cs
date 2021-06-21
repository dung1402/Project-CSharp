using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestUngDung.Areas.BanGiay.Models;
using TestUngDung.Commom;

namespace TestUngDung.Areas.BanGiay.Controllers
{
	public class HomeController : Controller
	{
		// GET: Admin/Home
		public ActionResult Index()
		{
			var session = (LoginModel)Session[Constants.USER_SESTION];
			if (session == null) return RedirectToAction("Index", "Login");
			return View();
		}
		public ActionResult Logout()
		{
			Session[Constants.USER_SESTION] = null;
			return RedirectToAction("Index", "Login");
		}
	}
}
