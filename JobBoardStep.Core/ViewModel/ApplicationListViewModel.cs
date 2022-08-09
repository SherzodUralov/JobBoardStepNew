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
    
        public DateTime UpdateDate { get; set; }
        public bool ApplicationStatus { get; set; }      
        public string JobCatName { get; set; }  
        public string UserEmployeerEmail { get; set; }
    }
}
