using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardStep.Core.ViewModel
{
    public class JobListViewModel
    {
        
        public int JobId { get; set; }      
        public string Salary { get; set; }   
        public DateTime CareateDate { get; set; }   
        public DateTime UpdateDate { get; set; }      
        public string Description { get; set; }           
        public string UserName { get; set; }            
        public string JobCatName { get; set; }       
        public string JobTypeName { get; set; }       
        public string ExperName { get; set; }
    }
}
