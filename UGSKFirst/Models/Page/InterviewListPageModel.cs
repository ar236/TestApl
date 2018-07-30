using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UGSKFirst.DB;

namespace UGSKFirst.Models.Page
{
	/// <summary>
	/// Модель для страниц отображающих список выполненных тестов.
	/// </summary>
	public class InterviewListPageModel
	{
		public InterviewListPageModel() { }

		/// <summary>
		/// По UserId заполняет Из БД список тестов выполненных этим пользователем.
		/// </summary>
		/// <param name="userId"></param>
		public InterviewListPageModel(string userId)
		{
			var cnt = new Entities();
			Interviews = cnt.Interview.Where(x => x.UserId == userId).ToList();
		}

		public List<Interview> Interviews { get; set; }
	}
}