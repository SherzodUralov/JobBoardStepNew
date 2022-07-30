using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardStep.Core.ViewModel
{
    public class UserCreateViewModel
    {
        [Key]
        [Required]
        public int UserId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string MiddleName { get; set; }
        [Required]
        [RegularExpression(@"\b[A-Z0-9._%-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b")]
        public string Email { get; set; }
        [Required]
        public string PassportNumber { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        public int InformationId { get; set; }
        public int RegionId { get; set; }
        public int UserTypeId { get; set; }
        public int InformationTranslateId { get; set; }
    }
}
