using ModelEF.Dao;
using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestUngDung.Areas.BanGiay.Controllers
{
	public class CategoryController : BaseController
	{
		// GET: Admin/Category
		//public ActionResult Index()
		//{
		//    return View();
		//}
		public ActionResult Index(int page = 1, int pagesize = 5)
		{
			var result = new CategoryDao();

			var model = result.ListAll();

			return View(model.ToPagedList(page, pagesize));
		}
		[HttpPost]
		public ActionResult Index(string searchString, int page = 1, int pagesize = 5)
		{
			var result = new CategoryDao();
			var model = result.LisWheretAll(searchString, page, pagesize);
			ViewBag.SearchString = searchString;
			return View(model);
		}
		//[HttpGet]
		//public ActionResult Create()
		//{
		//    return View();
		//}
		[HttpGet]
		public ActionResult Create(string id)
		{
			var dao = new CategoryDao();
			var result = dao.Find(id);
			if (result != null)
				return View(result);
			return View();


		}
		[HttpPost]
		public ActionResult Create(Category id)
		{

			if (ModelState.IsValid)
			{
				if (string.IsNullOrEmpty(id.CategoryID))
				{
					
					return View();
				}
				var dao = new CategoryDao();

				if (dao.Find(id.CategoryID) != null)
				{
					
					return RedirectToAction("Create", "Category");
				}




				var kq = dao.Insert(id);
				if (!string.IsNullOrEmpty(kq))
				{
					
					return RedirectToAction("Index", "Category");
				}
				else
				{
					
					return RedirectToAction("Create", "Category");
				}
			}
			return View();
		}
		[HttpGet]
		public ActionResult Edit(string abc)
		{
			var user = new CategoryDao().Find(abc);
			return View(user);
		}

		[HttpPost]
		public ActionResult Edit(Category category)
		{

			if (ModelState.IsValid)
			{
				var dao = new CategoryDao();
				if (string.IsNullOrEmpty(category.Name) && string.IsNullOrEmpty(category.CategoryID))
				{
					
					return RedirectToAction("Edit", "Category");
				}

				var kq = dao.Update(category);
				if (kq == true)
				{
					
					return RedirectToAction("Index", "Category");
				}
				else
				{
					
					return RedirectToAction("Edit", "Category");
				}

			}

			return View();
		}
		[HttpDelete]
		public ActionResult Delete(string id)
		{
			new CategoryDao().Delete(id);
			return RedirectToAction("Index", "Category");

		}
	}
}