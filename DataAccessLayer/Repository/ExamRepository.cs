using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
   public class ExamRepository:BaseRepository<Exam>
    {
        public ExamRepository(DatabaseContext context):base(context)
        {

        }
    }
}
