using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UnitOfWork
    {

        //Business ile bağlantı önce burada sağlanır. Veritabanı ile yapılacak olan tüm işlemleri, tek bir kanal aracılığı ile gerçekleştirme ve hafızada tutma işlemlerini sunmaktadır. Bu sayede işlemlerin toplu halde gerçekleştirilmesi ve hata durumunda geri alınabilmesi sağlamaktadır.

        DatabaseContext _context;
        public UnitOfWork()
        {
            _context = new DatabaseContext();
        }

        private UserRepository _userRepository;
        public UserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_context);
                }
                return _userRepository;
            }
        }
        private ArticleRepository _articleRepository;
        public ArticleRepository ArticleRepository
        {
            get
            {
                if (_articleRepository == null)
                {
                    _articleRepository = new ArticleRepository(_context);
                }
                return _articleRepository;
            }
        }
        private QuestionRepository _questionRepository;
        public QuestionRepository QuestionRepository
        {
            get
            {
                if (_questionRepository == null)
                {
                    _questionRepository = new QuestionRepository(_context);
                }
                return _questionRepository;
            }
        }

        private ExamRepository _examRepository;
        public ExamRepository ExamRepository
        {
            get
            {
                if (_examRepository == null)
                {
                    _examRepository = new ExamRepository(_context);
                }
                return _examRepository;
            }
        }
        private AnswerRepository _answerRepository;
        public AnswerRepository AnswerRepository
        {
            get
            {
                if (_answerRepository == null)
                {
                    _answerRepository = new AnswerRepository(_context);
                }
                return _answerRepository;
            }
        }
        //Değişiklikleri onaylama hata varsa gösterme.
        public bool ApplyChanges()
        {
            bool isSuccess = false;
            DbContextTransaction _tran;
            _tran = _context.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
            try
            {
                _context.SaveChanges();
                _tran.Commit();
                isSuccess = true;
            }
            catch (Exception ex)
            {
                _tran.Rollback();
                isSuccess = false;
                throw new Exception(ex.Message);
            }
            finally
            {
                _tran.Dispose();
            }
            return isSuccess;
        }

    }
}
