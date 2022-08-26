using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardStep.Core.ViewModel
{
    public class AppCreateVMmin
    {
        public int AplicationId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool Status { get; set; }
        public int JobId { get; set; }
         public string? FilePath { get; set; }
        public int UserId { get; set; }
    }
}
