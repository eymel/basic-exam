using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Exam
    {
        public Exam()
        {
            Questions = new List<Question>();
                
             
        }
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }

        public int ArticleID { get; set; }
        public virtual Article Article { get; set; }

        public virtual List<Question> Questions { get; set; }
    }
}
