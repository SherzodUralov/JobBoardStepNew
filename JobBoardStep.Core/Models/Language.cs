using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardStep.Core.Models
{
    public class Language
    {
        public int Id { get; set; }
        public string LanguageName { get; set; }
        public bool LanguageStatus { get; set; }
        public List<JobTypeTranslate> JobTypeTranslates { get; set; }
        public List<RegionTranslate> RegionTranslates { get; set; }
        public List<InformationTranslate> InformationTranslates { get; set; }
        public List<ExperienceTranslate> ExperienceTranslates { get; set; }
        public virtual List<JobCategoryTranslate> JobCategoryTranslates { get; set; }
    }
}
