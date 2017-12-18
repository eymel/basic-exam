using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Map
{
    public class ExamMap:EntityTypeConfiguration<Exam>
    {
        public ExamMap()
        {
            HasKey(x => x.ID);

            HasRequired(x => x.Article).WithMany().HasForeignKey(x=>x.ArticleID).WillCascadeOnDelete(true);

            
        }
    }
}
