using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardStep.Core.Models
{
    public class JobCategory
    {
        public int Id { get; set; }
        public string JobCatName { get; set; }
        public List<JobCategoryTranslate> JobCategoryTranslates { get; set; }
        public List<Job> Jobs { get; set; }
    }
}
