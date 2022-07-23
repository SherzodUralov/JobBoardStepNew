using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardStep.Core.Models
{
    public class Region
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool RegionStatus { get; set; }
        public List<RegionTranslate> RegionTranslates { get; set; }
        public List<User> Users { get; set; }
    }
}
