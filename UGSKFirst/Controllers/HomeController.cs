using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UGSKFirst.DB;

namespace UGSKFirst.Controllers
{
	public class HomeController : Controller
	{
		[Authorize]
		public ActionResult Index()
		{
			var interviewTemplates = (new Entities()).InterviewTemplate.ToList();
			return View(interviewTemplates);
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}