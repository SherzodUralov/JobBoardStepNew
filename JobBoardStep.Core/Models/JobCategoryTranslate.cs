using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardStep.Core.Models
{
    public class JobCategoryTranslate
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string JobCatName { get; set; }
        [ForeignKey("Language")]
        public int LanguageId { get; set; }
        public Language Language { get; set; }
        [ForeignKey("JobCategory")]
        public int JobCatId { get; set; }
        public JobCategory JobCategory { get; set; }
    }
}
