using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class ExamModel

    {
        public ExamModel()
        {
            Questions = new List<QuestionModel>();


        }
        public int ID { get; set; }      
        public virtual List<QuestionModel> Questions { get; set; }
    }

    public class QuestionModel
    {
        
        public QuestionModel()
        {
            Answers = new List<AnswerModel>();


        }
        public string Content { get; set; }
        public virtual List<AnswerModel> Answers { get; set; }
      

    }

    public class AnswerModel
    {
        public string Content { get; set; }
        public bool? IsRight { get; set; }
      
    }
}