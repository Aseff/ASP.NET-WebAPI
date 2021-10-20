using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIProject.Models
{
    public class FreeTextQuestion: Question
    {
        public int MaxAnswerLength { get; set; }
    }
}
