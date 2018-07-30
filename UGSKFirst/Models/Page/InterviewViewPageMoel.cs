using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UGSKFirst.DB;

namespace UGSKFirst.Models.Page
{
	/// <summary>
	/// Модель страницы для отображения теста.
	/// </summary>
	public class InterviewViewPageModel
	{
		public InterviewViewPageModel() { }

		/// <summary>
		/// Загружает по id данные теста.
		/// </summary>
		/// <param name="id"></param>
		public InterviewViewPageModel(int id)
		{
			var cnt = new Entities();

			Interview = cnt.Interview.First(xx => xx.Id == id);
		}

		public Interview Interview { get; set; }
	}
}