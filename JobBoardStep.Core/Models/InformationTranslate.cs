using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardStep.Core.Models
{
    public class InformationTranslate
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [ForeignKey("Language")]
        public int LanguageId { get; set; }
        public Language Language { get; set; }
        [ForeignKey("Information")]
        public int InformationId { get; set; }
        public Information Information { get; set; }
        public List<User> Users { get; set; }
    }
}
