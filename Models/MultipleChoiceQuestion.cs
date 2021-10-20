using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIProject.Models
{
    public class MultipleChoiceQuestion: Question
    {
        public string SerializedPossibleAnswers { get; set; }

        [NotMapped]
        public List<string> PossibleAnswers
        {
            get
            {
                return SerializedPossibleAnswers.Split(";").ToList();
            }
            set
            {
                SerializedPossibleAnswers = String.Join(";", value);
            }
        }


    }
}
