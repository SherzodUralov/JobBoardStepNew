using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardStep.Core.Models
{
    public class JobCategory
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        [Required]
        public DateTime UpdateDate { get; set; }
        public List<JobCategoryTranslate> JobCategoryTranslates { get; set; }
        public List<Job> Jobs { get; set; }
    }
}
