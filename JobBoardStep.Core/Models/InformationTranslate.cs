using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardStep.Core.Models
{
    public class InformationTranslate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LanguageId { get; set; }
        public Language Language { get; set; }
        public int InformationId { get; set; }
        public Information Information { get; set; }
        public List<User> Users { get; set; }
    }
}
