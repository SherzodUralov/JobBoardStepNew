using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardStep.Core.Models
{
    public class Application
    {
        [Key]
        [Required]
        public int ApplicationId { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        [Required]        
        public DateTime UpdateDate { get; set; }
        public bool ApplicationStatus { get; set; }
        public Job Job { get; set; }
        [ForeignKey("Job")]
        public int JobId { get; set; }
        public User Users { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
    }
}
