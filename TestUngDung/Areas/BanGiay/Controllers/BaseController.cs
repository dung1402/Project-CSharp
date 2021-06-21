using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TestUngDung.Areas.BanGiay.Models;
using TestUngDung.Commom;

namespace TestUngDung.Areas.BanGiay.Controllers
{
	public class BaseController : Controller
	{
		protected override void OnActionExecuted(ActionExecutedContext filterContext)
		{
			var session = (LoginModel)Session[Constants.USER_SESTION];
			if (session == null)
			{
				filterContext.Result = new RedirectToRouteResult(new
					RouteValueDictionary(new { controller = "Login", action = "Index", Areas = "Admin" }));
			}
			base.OnActionExecuted(filterContext);
		}
	}
}
