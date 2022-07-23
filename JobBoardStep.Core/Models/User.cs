using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardStep.Core.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string PassportNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime CreateDate { get; set; }
        public List<Job> Jobs { get; set; }
        public Information Information { get; set; }
        public int InformationId { get; set; }
        public Region Region { get; set; }
        public int RegionId { get; set; }
        public UserType UserType { get; set; }
        public int UserTypeId { get; set; }
        public RegionTranslate RegionTranslate { get; set; }
        public int RegionTranslateId { get; set; }
        public InformationTranslate InformationTranslate { get; set; }
        public int InformationTranslateId { get; set; }
        public List<Application>? Applications { get; set; }
    }
}
