using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIProject.Models
{
    public class QuestionFormAnswer
    {
        [Key]
        public long Id { get; set; }
        public long QuestionFormId{ get; set; }

        public ICollection<Answer> Answers { get; set; }
    }

    
}
