using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
 public  class QuestionRepository:BaseRepository<Question>
    {
        public QuestionRepository(DatabaseContext context):base(context)
        {

        }

    }
}
