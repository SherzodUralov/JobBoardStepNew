using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardStep.Core.ViewModel
{
    public class ChangeModel
    {
        [Required]
        public string Email { get; set; }
        [Required(ErrorMessage = "OldPassword is required.")]
        public string OldPassword { get; set; }
        [Required(ErrorMessage = "NewPassword is required.")]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "ConfirmPassword is required.")]
        [Compare("NewPassword", ErrorMessage = "NewPassword and ConfirmPassword must match.")]
        public string ConfirmPassword { get; set; }
    }
}
