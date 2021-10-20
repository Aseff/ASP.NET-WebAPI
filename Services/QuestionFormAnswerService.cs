using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebAPIProject.Data;
using WebAPIProject.Interfaces;
using WebAPIProject.Models;
using WebAPIProject.DTOs;

using Microsoft.EntityFrameworkCore;

namespace WebAPIProject.Services
{
    public class QuestionFormAnswerService : IQuestionFormAnswerService
    {

        private readonly HEMDbContext _context;

        public QuestionFormAnswerService(HEMDbContext context)
        {
            this._context = context;
        }
       
        public IEnumerable<QuestionFormAnswer> GetQuestionFormAnswers()
        {
            return _context.QuestionFormsAnswer.Include(qf => qf.Answers).ToList();

        }

        public bool QuestionFormAnswerExistsById(long id)
        {
            return _context.QuestionFormsAnswer.Any(qf => qf.QuestionFormId == id);
        }

        public QuestionFormAnswer SaveQuestionFormAnswer(QuestionFormAnswer questionFormAnswer)
        {
            if (CheckingQuestionFormAnswer(questionFormAnswer))
            {
                throw new QuestionFormAnswerExistsException();
            }
            // Register the new question form as an entity tracekd by EF
            var result = _context.QuestionFormsAnswer.Add(questionFormAnswer);
            // Save to database
            _context.SaveChanges();
            return result.Entity;
        }

        public bool CheckingQuestionFormAnswer(QuestionFormAnswer questionFormAnswer)
        {
            QuestionForm questionForm =
                 _context.QuestionForms.Include(qf => qf.Questions)
                .FirstOrDefault(qf => qf.Id == questionFormAnswer.QuestionFormId);
            if (questionForm == null)
            {
                return false;
            }

            foreach (var answer in questionFormAnswer.Answers)
            {
                Question question = questionForm.Questions.FirstOrDefault(ques => ques.Id == answer.QuestionId);

                if (question == null)
                {
                    return false;
                }
                QuestionDTO questionDto = new QuestionDTO(question);
                 if (question is FreeTextQuestion)
                 {
                    if (answer.AnswerText.Length > questionDto.MaxAnswerLength)
                        return false;
                 }
               else if (question is MultipleChoiceQuestion)
                {
                    if (!questionDto.PossibleAnswers.Contains(answer.AnswerText))
                        return false;
                }

                else if (question is TrueOrFalseQuestion)
                {
                    if (answer.AnswerText.ToLower() != "true" && answer.AnswerText.ToLower() != "false")
                        return false;
                }
              
            }
            return true;
        }
        
     }   
}
