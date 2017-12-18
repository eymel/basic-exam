using DataAccessLayer.Map;
using Entity;
using System.Data.Entity;

namespace DataAccessLayer
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext() : base("DefaultDb")
        {

        }

        internal DbSet<User> User { get; set; }
        internal DbSet<Exam> Exam { get; set; }
        internal DbSet<Question> Question { get; set; }
        internal DbSet<Answer> Answer { get; set; }
        internal DbSet<Article> Article { get; set; }
      


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new ExamMap());
            modelBuilder.Configurations.Add(new ArticleMap());
            modelBuilder.Configurations.Add(new AnswerMap());
            modelBuilder.Configurations.Add(new QuestionMap());
         
            base.OnModelCreating(modelBuilder);
        }

     
    }
}