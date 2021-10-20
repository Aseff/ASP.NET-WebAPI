using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebAPIProject.Models
{
    public class Answer
    {
        [Key]
        public long Id { get; set; }
        public long QuestionId { get; set; }
        public string AnswerText { get; set; }
    }
}
