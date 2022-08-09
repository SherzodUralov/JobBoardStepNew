using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardStep.Core.ViewModel
{
    public class RoleMapViewModel
    {
        [Required]
        public int RoleId { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
