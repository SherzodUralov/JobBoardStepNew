using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardStep.Core.Models
{
    public class JobType
    {
        public int Id { get; set; }
        public DateTime CareateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool JobTypeStatus { get; set; }
        public List<JobTypeTranslate> JobTypeTranslates { get; set; }
        public virtual List<Job> Jobs { get; set; }
    }
}
