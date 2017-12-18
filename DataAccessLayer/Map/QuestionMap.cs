using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Map
{
  public  class QuestionMap:EntityTypeConfiguration<Question>
    {
        public QuestionMap()
        {

            HasKey(x => x.ID);
            Property(x => x.Content).IsRequired();

            HasRequired(x => x.Exam).WithMany(x=>x.Questions).HasForeignKey(x => x.ExamID).WillCascadeOnDelete(true);

            
            


        }
    }
}
