using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UGSKFirst.DB;

namespace UGSKFirst.Models
{
	public class InterviewCreatePageModel
	{
		public InterviewCreatePageModel()
		{

		}

		/// <summary>
		/// Создает тест для заполнений по Id шаблона теста в БД.
		/// </summary>
		/// <param name="templateId"></param>
		public InterviewCreatePageModel(int templateId)
		{
			InterviewTemplate = new Entities().InterviewTemplate.First(xx => xx.Id == templateId);
			Answers = new List<AnswerModel>();
			foreach (DB.Question iQuestion in InterviewTemplate.Questions)
			{
				Answers.Add(new AnswerModel(iQuestion));
			}
		}

		public InterviewTemplate InterviewTemplate { get; set; }
		public List<AnswerModel> Answers { get; set; }

		/// <summary>
		/// Сохранение в БД Выполненного теста.
		/// </summary>
		/// <param name="userId">Пользователь который сохраняет тест.</param>
		public void SaveAnswerDb(string userId)
		{
			var cnt = new Entities();
			var newInterview = cnt.Interview.Add(new DB.Interview()
			{
				UserId = userId,
				InterviewTemplateId = InterviewTemplate.Id
			});

			foreach (AnswerModel iAnswer in Answers)
			{
				var newAnswer = new DB.Answer()
				{
					AnswerTxt = iAnswer.AnswerTxt,
					SelectedOptionId = iAnswer.SelectedOption,
					QuestionId = iAnswer.Question.Id
				};

				if (iAnswer.Question.Type == 3) //Вопрос с множественным выбором.
				{
					foreach (var iAnswerAnswerOption in iAnswer.AnswerOptions)
					{
						if (iAnswerAnswerOption.isSelected)
						{
							var qo = cnt.QuestionOption.Where(xx => xx.Id == iAnswerAnswerOption.QuestionOptionId).ToList();

							newAnswer.AnswerSelectedOption.Add(new AnswerSelectedOption()
							{
								OptionId = iAnswerAnswerOption.QuestionOptionId
							});
						}
					}
				}

				newInterview.Answer.Add(newAnswer);
			}

			cnt.SaveChanges();
		}

	}
}