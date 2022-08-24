using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardStep.Core.ViewModel
{
    public class ApplicationListViewModel
    {

        public int ApplicationId { get; set; }
        public DateTime CreateDate { get; set; }   
        public bool ApplicationStatus { get; set; }
        public string? FilePath { get; set; }
        public string JobCatName { get; set; }  
        public string Phone { get; set; }
        public string FirstName { get; set; }
    }
}
