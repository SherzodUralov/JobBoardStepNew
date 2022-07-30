using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardStep.Core.ViewModel
{
    public class ExperListViewModel
    {
        public int Id { get; set; }
        public string ExperName { get; set; }
        public string Langname { get; set; }
        public DateTime CareateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool ExperienceStatus { get; set; }

    }
}
