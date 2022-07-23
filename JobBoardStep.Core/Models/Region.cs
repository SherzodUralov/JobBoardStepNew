using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardStep.Core.Models
{
    public class Region
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        [Required]
        public DateTime UpdateDate { get; set; }
        public bool RegionStatus { get; set; }
        public List<RegionTranslate> RegionTranslates { get; set; }
        public List<User> Users { get; set; }
    }
}
