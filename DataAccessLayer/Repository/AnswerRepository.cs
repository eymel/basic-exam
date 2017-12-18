using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
  public  class AnswerRepository:BaseRepository<Answer>
    {
        public AnswerRepository(DatabaseContext context):base(context)
        {

        }
    }
}
