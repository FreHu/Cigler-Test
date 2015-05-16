using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cigler_Telerik.DAL;

namespace Cigler.Controllers
{
	
	public class SeedController : Controller
	{
		private CiglerContext db = new CiglerContext();
		public ActionResult Index()
		{
			var initializer = new AppInitializer();
			initializer.SeedDebug(db);
			return RedirectToAction("Index", "Home");
		}
	}
}