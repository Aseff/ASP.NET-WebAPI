using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProject.Interfaces;
using WebAPIProject.Models;
using WebAPIProject.Services;
using WebAPIProject.Data;
using WebAPIProject.DTOs;

namespace WebAPIProject.Controllers
{
    [Route("api/question-form-answer")]
    [ApiController]
    public class QuestionFormAnswerController : ControllerBase
    {
        private readonly IQuestionFormAnswerService questionFormAnswerService;
        public QuestionFormAnswerController(IQuestionFormAnswerService service)
        {
            this.questionFormAnswerService = service;
        }


        [HttpGet]
        public ActionResult<IEnumerable<QuestionFormDTO>> GetQuestionFormAnswer()
        {
            return Ok(questionFormAnswerService.GetQuestionFormAnswers().Select(qf => new QuestionFormAnswerDTO(qf)));
        }

       
       


        [HttpPost]
        public ActionResult<QuestionFormAnswerDTO> CreateNewQuestionFormAnswer(QuestionFormAnswerDTO questionFormAnswerDTO)
        {
            
            if (questionFormAnswerDTO == null)
            {
                return BadRequest("QuestionFormAnswer data must be set!");
            }
            try
            {

                QuestionFormAnswer createdEntity = questionFormAnswerService.SaveQuestionFormAnswer(questionFormAnswerDTO.ToEntity());

                return CreatedAtAction(
                nameof(GetQuestionFormAnswer),
                new { QuestionFormAnswerId = createdEntity.Id },
                new QuestionFormAnswerDTO(createdEntity));
            }
            catch (QuestionFormExistsException)
            {
                return Conflict("The desired ID for the QuestionForm is already taken!");
            }
        }
    }
}
