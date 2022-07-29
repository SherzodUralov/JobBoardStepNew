using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardStep.Core.Models
{
    public class Experience
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public DateTime CareateDate { get; set; }
        [Required]
        public DateTime UpdateDate { get; set; }
        public bool ExperienceStatus { get; set; }
        public List<ExperienceTranslate> ExperienceTranslates { get; set; }
        public List<Job> Jobs { get; set; }
    }
}
