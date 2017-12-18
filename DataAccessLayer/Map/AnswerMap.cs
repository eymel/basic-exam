using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Map
{
  public  class AnswerMap:EntityTypeConfiguration<Answer>
    {
        public AnswerMap()
        {
            HasKey(x=>x.ID);
            Property(x=>x.Content).IsRequired();

            HasRequired(x => x.Question).WithMany(x=>x.Answers).HasForeignKey(x => x.QuestionID).WillCascadeOnDelete(true);
        }
    }
}
