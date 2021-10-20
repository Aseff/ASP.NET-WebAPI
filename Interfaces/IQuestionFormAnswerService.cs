using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProject.Data;
using WebAPIProject.Models;
namespace WebAPIProject.Interfaces
{
   public interface IQuestionFormAnswerService
    {
        IEnumerable<QuestionFormAnswer> GetQuestionFormAnswers();
     
        QuestionFormAnswer  SaveQuestionFormAnswer(QuestionFormAnswer questionFormAnswer);
    }
}
