using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardStep.Core.Models
{
    public class User
    {
        [Key]
        [Required]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }
        //[Required]
        //[RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "email is faield")]
        public string? Email { get; set; }
        public string? PassportNumber { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime CreateDate { get; set; }= DateTime.Now;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string? PhotoFilePath { get; set; }
        public List<Job>? Jobs { get; set; }
        public Information? Information { get; set; }
        [ForeignKey("Information")]
        public int? InformationId { get; set; }
        public Region? Region { get; set; }
        [ForeignKey("Region")]
        public int? RegionId { get; set; }
        public UserType? UserType { get; set; }
        [ForeignKey("UserType")]
        public int? UserTypeId { get; set; }
        public InformationTranslate? InformationTranslate{ get; set; }
        [ForeignKey("InformationTranslate")]
        public int? InformatTrId { get; set; }
        public List<Application>? Applications { get; set; }
        public List<RoleMap>? RoleMaps { get; set; } = new List<RoleMap>();
    }
}
