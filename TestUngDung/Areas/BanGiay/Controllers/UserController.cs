using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelEF.Dao;
using PagedList;

namespace TestUngDung.Areas.BanGiay.Controllers
{
	public class UserController : BaseController
	{
		// GET: Admin/User
		public ActionResult Index(int page = 1, int pagesize = 5)
		{
			var user = new UserAccountDao();
			var model = user.ListAll();
			return View(model.ToPagedList(page, pagesize));
		}
		//hàm trả về kq tìm kiếm
		[HttpPost]
		public ActionResult Index(string seachString, int page = 1, int pagesize = 5)
		{
			var user = new UserAccountDao();
			var model = user.ListWhereAll(seachString, page, pagesize);
			ViewBag.SearchString = seachString;
			return View(model.ToPagedList(page, pagesize));
		}

		//[HttpGet]
		//public ActionResult Create()
		//{
		//    return View();
		//}
		[HttpGet]
		public ActionResult Create(string id)
		{
			var dao = new UserAccountDao();
			var result = dao.Find(id);
			if (result != null)
			{
				result.Password = "";
				return View(result);
			}
			return View();
		}
		[HttpPost]
		public ActionResult Create(UserAccount model)
		{
			if (ModelState.IsValid)
			{

				var dao = new UserAccountDao();
				var id = model.Password;
				model.Password = id;
				string result = "";
				//Tim tên đăng nhập trùng k nếu trùng trả về trang create
				result = dao.Insert(model);

				if (!string.IsNullOrEmpty(result))
				{
					return RedirectToAction("Index", "User");
				}
				else
				{
					ModelState.AddModelError("", "Tạo người dùng  Không Thành Công");
				}
			}
			return View(model);
		}
		//Xóa
		[HttpDelete]
		public ActionResult delete(int id)
		{
			new UserAccountDao().delete(id);
			return RedirectToAction("Index", "User");

		}
	}
}