using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardStep.Core.Models
{
    public class Information
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool InformationStatus { get; set; }
        public List<InformationTranslate> InformationTranslates { get; set; }
        public List<User> Users { get; set; }
    }
}
