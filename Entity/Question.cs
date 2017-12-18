using System.Collections.Generic;

namespace Entity
{
    public class Question
    {
        public int ID { get; set; }
        public Question()
        {
            Answers = new List<Answer>();
               
         
        }
        public string Content { get; set; }
        public virtual List<Answer> Answers { get; set; }
        public int ExamID { get; set; }

        public  virtual Exam Exam { get; set; }
    }
}