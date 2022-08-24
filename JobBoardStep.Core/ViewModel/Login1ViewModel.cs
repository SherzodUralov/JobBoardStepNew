using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardStep.Core.ViewModel
{
	public class Login1ViewModel
	{
		[Required]
		public string PhoneNamber { get; set; }
		[Required]
		public string Password { get; set; }
	}
}
