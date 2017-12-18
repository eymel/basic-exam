using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class ArticleRepository:BaseRepository<Article>
    {
        public ArticleRepository(DatabaseContext context):base(context)
        {

        }
    }
}
