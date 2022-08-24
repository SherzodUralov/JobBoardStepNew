using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardStep.Core.ViewModel
{
    public class JobCreateViewModel
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
        [Required]
        public int JobTypeTrId { get; set; }
        [Required]
        public int ExperienceTrId { get; set; }
       
        public int UserId { get; set; }
        [Required]
        public int JobCateTrId { get; set; }
     
      

    }
}
