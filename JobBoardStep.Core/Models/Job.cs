using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardStep.Core.Models
{
    public class Job
    {
        [Key]
        [Required]
        public int JobId { get; set; }
        [Required]  
        public string Salary { get; set; }
        [Required]
        public DateTime CareateDate { get; set; }
        [Required]
        public DateTime UpdateDate { get; set; }
        [Required]
        public string Description { get; set; }
        public JobType JobType { get; set; }
        [ForeignKey("JobType")]
        public int JobTypeId { get; set; }
        public List<Application> Application { get; set; }
        public Experience Experience { get; set; }
        [ForeignKey("Experience")]
        public int ExperienceId { get; set; }
        public User User { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public JobCategory JobCategory { get; set; }
        [ForeignKey("JobCategory")]
        public int JobCateId { get; set; }
        public JobCategoryTranslate JobCategoryTranslate { get; set; }
        [ForeignKey("JobCategoryTranslate")]
        public int JobCatTId { get; set; }
        public JobTypeTranslate JobTypeTranslate { get; set; }
        [ForeignKey("JobTypeTranslate")]
        public int JobTypeTId { get; set; }
        public ExperienceTranslate ExperienceTranslate { get; set; }
        [ForeignKey("ExperienceTranslate")]
        public int ExperTId { get; set; }
    }
}
