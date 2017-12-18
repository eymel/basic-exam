using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Map
{
   public class ArticleMap:EntityTypeConfiguration<Article>
    {
        public ArticleMap()
        {
            HasKey(x => x.ID);
            Property(x => x.Title).IsRequired();
            Property(x => x.Content).IsRequired();

        }
    }
}
