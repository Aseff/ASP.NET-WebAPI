using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProject.Models;


namespace WebAPIProject.DTOs
{
    public class QuestionFormAnswerDTO
    {
        public long Id { get; set; }
        public long QuestionFormId { get; set; }

        public List<AnswerDTO> Answers { get; set; }


        public QuestionFormAnswerDTO()
        {

        }

        public QuestionFormAnswerDTO(QuestionFormAnswer  questionFormAnswer)
        {
            this.QuestionFormId=questionFormAnswer.QuestionFormId;
            this.Answers=questionFormAnswer.Answers.Select(qfa=> new AnswerDTO(qfa)).ToList();

        }
        public QuestionFormAnswer ToEntity()
        {
            return new QuestionFormAnswer()
            {
                QuestionFormId = this.QuestionFormId,
                Answers = this.Answers.Select(q => q.ToEntity()).ToList()
            };

        }


    }
}
