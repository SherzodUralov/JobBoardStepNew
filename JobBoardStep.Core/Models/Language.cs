using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardStep.Core.Models
{
    public class Language
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string LanguageName { get; set; }
        public bool LanguageStatus { get; set; }
        public List<JobTypeTranslate>? JobTypeTranslates { get; set; }
        public List<InformationTranslate>? InformationTranslates { get; set; }
        public List<ExperienceTranslate>? ExperienceTranslates { get; set; }
        public List<JobCategoryTranslate>? JobCategoryTranslates { get; set; }
    }
}
