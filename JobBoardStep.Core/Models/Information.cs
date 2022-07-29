using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardStep.Core.Models
{
    public class Information
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        [Required]
        public DateTime UpdateDate { get; set; }
        public bool InformationStatus { get; set; }
        public List<InformationTranslate> InformationTranslates { get; set; }= new List<InformationTranslate>();
        public List<User> Users { get; set; }
    }
}
