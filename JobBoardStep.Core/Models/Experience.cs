using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardStep.Core.Models
{
    public class Experience
    {
        public int Id { get; set; }
        public DateTime CareateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool ExperienceStatus { get; set; }
        public List<ExperienceTranslate> ExperienceTranslates { get; set; }
        public List<Job> Jobs { get; set; }
    }
}
