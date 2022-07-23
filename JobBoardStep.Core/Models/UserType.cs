using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardStep.Core.Models
{
    public class UserType
    {
        public int UserTypeId { get; set; }
        public string UserTypeName { get; set; }
        public List<User> Users { get; set; }
    }
}
