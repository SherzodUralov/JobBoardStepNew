using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardStep.Core.Models
{
    public class Application
    {
        public int ApplicationId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool ApplicationStatus { get; set; }
        public Job Job { get; set; }
        public int JobId { get; set; }
        public User Users { get; set; }
        public int UserId { get; set; }
    }
}
