using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardStep.Core.Models
{
    public class ExperienceTranslate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LanguageId { get; set; }
        public Language Language { get; set; }
        public int ExperienceId { get; set; }
        public Experience Experience { get; set; }
    }
}
