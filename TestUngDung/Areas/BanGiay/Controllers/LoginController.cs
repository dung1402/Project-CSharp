using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelEF.Dao;
using TestUngDung.Areas.BanGiay.Models;
using TestUngDung.Commom;

namespace TestUngDung.Areas.BanGiay.Controllers
{
	public class LoginController : Controller
	{
		// GET: Admin/Login
		public ActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public ActionResult Index(LoginModel user)
		{
			if (ModelState.IsValid)
			{
				var dao = new UserAccountDao();
				var result = dao.Login(user.UserName, user.Password);
				if (result == 1)
				{
					//ModelState.AddModelError("", "Đăng Nhập Thành Công");
					Session.Add(Constants.USER_SESTION, user);
					return RedirectToAction("Index", "Home");
				}
				else
				{
					ModelState.AddModelError("", "Đăng Nhập Không Thành Công");
				}
			}
			return View();
		}
	}
}