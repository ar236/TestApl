using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using UGSKFirst.DB;
using UGSKFirst.Models;
using UGSKFirst.Models.Page;


namespace UGSKFirst.Controllers
{
    public class InterviewController : Controller
    {
        // GET: Interview
        public ActionResult Index()
        {
			return View(new InterviewListPageModel(User.Identity.GetUserId()));
        }

	    public ActionResult Show(int interviewId)
	    {
		    return View(new InterviewViewPageModel(interviewId));
	    }

	    public ActionResult Create(int? templateId)
	    {
		    var pm = new InterviewCreatePageModel(templateId.Value);

		    return View(pm);
	    }

		
		[HttpPost]
	    public ActionResult Create(InterviewCreatePageModel model)
		{
			model.SaveAnswerDb(User.Identity.GetUserId());
			return RedirectToAction("Index");
		}
	}
}