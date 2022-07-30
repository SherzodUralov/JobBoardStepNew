﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardStep.Core.ViewModel
{
    public class JobTypeViewModel
    {
        public int Id { get; set; }
        public string JobTypeName { get; set; }
        public string LangName { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool JobTypeStatus { get; set; }

    }
}
