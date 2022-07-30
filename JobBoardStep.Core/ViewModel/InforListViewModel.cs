using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardStep.Core.ViewModel
{
    public class InforListViewModel
    {
        public int Id { get; set; }
        public string InforName { get; set; }
        public string LangName { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool InformationStatus { get; set; }
    }
}
