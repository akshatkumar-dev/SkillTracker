using SkillTracker.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SkillTracker.Dtos
{
    public class CreateProfileDto
    {
        public CreateProfileDto(string name, string associateid, string mobile, string email, TechnicalSkillModel technicalskill, NonTechnicalSkillModel nontechnicalskill)
        {
            this.name = name;
            this.associateid = associateid;
            this.mobile = mobile;
            this.email = email;
            this.technicalskill = technicalskill;
            this.nontechnicalskill = nontechnicalskill;
        }

        [Required]
        [MinLength(5, ErrorMessage = "The minimum length of {0} should be 5")]
        [MaxLength(30, ErrorMessage = "The maximum length of {0} should be 30")]
        public string name { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "The minimum length of {0} should be 5")]
        [MaxLength(30, ErrorMessage = "The maximum length of {0} should be 30")]
        [RegularExpression(@"^CTS\w*", ErrorMessage = "The field {0} must start with CTS")]
        public string associateid { get; set; }

        [Required]
        [RegularExpression(@"[0-9]{10}",ErrorMessage = "The field {0} must be of 10 characters and only numeric")]
        public string mobile { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string email { get; set; }
        public TechnicalSkillModel technicalskill { get; set; } 
        public NonTechnicalSkillModel nontechnicalskill { get; set; }

    }
}
