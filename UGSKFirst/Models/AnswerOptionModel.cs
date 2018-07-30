using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UGSKFirst.DB;

namespace UGSKFirst.Models
{
	/// <summary>
	/// Прокси класс для сохранения варианта выбора пользователя на вопрос с множественным выбором.
	/// </summary>
	public class AnswerOptionModel
	{
		public QuestionOption QuestionOption { get; set; }
		public int QuestionOptionId { get; set; }

		/// <summary>
		/// true - пользователь выбрал это вариант.
		/// </summary>
		/// <remarks>
		/// При сохранении в БД только выбранные пользователем варианты сохраняются.
		/// </remarks>
		public bool isSelected { get; set; }
	}
}