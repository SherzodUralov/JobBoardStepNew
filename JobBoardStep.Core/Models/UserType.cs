using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardStep.Core.Models
{
    public class UserType
    {
        [Key]
        [Required]
        public int UserTypeId { get; set; }
        [Required]
        public string UserTypeName { get; set; }
        public List<User> Users { get; set; }
    }
}
