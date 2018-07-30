using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UGSKFirst.DB;

namespace UGSKFirst.Models
{
	/// <summary>
	/// Прокси ответа на один пункт теста.
	/// </summary>
	public class AnswerModel
	{
		public AnswerModel()
		{
			AnswerOptions = new List<AnswerOptionModel>();
		}

		/// <summary>
		/// По шаблону вопроса из БД создает экземпляр класса где будет храниться
		/// что ответил пользователь на вопрос до сохранения в БД. 
		/// </summary>
		/// <param name="question"></param>
		public AnswerModel(Question question)
		{
			Question = question;

			AnswerOptions = new List<AnswerOptionModel>();
			foreach (var questionOption in Question.QuestionOption.ToList())
			{
				AnswerOptions.Add(new AnswerOptionModel() {QuestionOption = questionOption, QuestionOptionId = questionOption.Id});
			}
			
		}

		/// <summary>
		/// Ссылка на вопрос чтобы отобразить параметры вопроса на странице.
		/// </summary>
		public Question Question { get; set; }
		/// <summary>
		/// Текстовый ответ пользователя.
		/// </summary>
		public string AnswerTxt { get; set; }
		/// <summary>
		/// Выбор пользователя на ответ с одним возможным вариантом.
		/// </summary>
		public int? SelectedOption { get; set; }
		/// <summary>
		/// Список выбранны пользователем ответов на вопрос с множественным выбором.
		/// </summary>
		public List<AnswerOptionModel> AnswerOptions { get; set; }
	}
}