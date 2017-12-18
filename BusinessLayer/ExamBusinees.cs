using DataAccessLayer;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ExamBusinees
    {
        UnitOfWork _uof;
        public ExamBusinees()
        {
            _uof = new UnitOfWork();
        }
        public bool SaveExam(Exam exam )
        {
            if (string.IsNullOrWhiteSpace(exam.Article.Title) && string.IsNullOrWhiteSpace(exam.Article.Content))
            {
                throw new Exception("Article boş gönderilemez");
            }
            if (exam.Questions.Count!=4)
            {
                
                throw new Exception("Lütfen 4 tane soru giriniz");
            }
      
            foreach (var item in exam.Questions)
            {
                if (string.IsNullOrWhiteSpace(item.Content))
                {
                    throw new Exception("Lütfen soruları yazınız");

                }
               
                if (item.Answers.Count!=4)
                {
                    throw new Exception("Lütfen soruların cevaplarını eksiksiz giriniz");
                }
                foreach (var answer in item.Answers)
                {
                    if (string.IsNullOrWhiteSpace(answer.Content))
                    {
                        throw new Exception("Lütfen CEVAP ALANLARINI BOŞ BIRAKMAYIN");
                    }
                }
            }

            try
            {
              
                
                _uof.ArticleRepository.Add(exam.Article);

                exam.CreatedDate = DateTime.Now;
                exam.ArticleID = exam.Article.ID;
                _uof.ExamRepository.Add(exam);
                foreach (var item in exam.Questions)
                {
                    item.ExamID = exam.ID;
                    _uof.QuestionRepository.Add(item);
                    foreach (var answer in item.Answers)
                    {
                        answer.QuestionID = item.ID;
                        _uof.AnswerRepository.Add(answer);
                    }
                
                }


                


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return _uof.ApplyChanges();


        }
        public List<Exam> GetList()
        {
           return _uof.ExamRepository.GetAll();

        }
        public bool Delete(int id)
        {
            Exam exam = _uof.ExamRepository.Get(id);
            if (exam!=null)
            {
            _uof.ExamRepository.Delete(exam);

            }
            return _uof.ApplyChanges() ;
        }
        public Exam Get(int id)
        {

            
            return _uof.ExamRepository.Get(id);

        }

        public Answer GetAnswer(int id) {
            return _uof.AnswerRepository.Get(id);
                }
    }
}
