using SkillTracker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillTracker.Dtos
{
    public class FilterProfileDto
    {
        public FilterProfileDto(string name, string associateid, string mobile, string email, TechnicalSkillModel technicalskill, NonTechnicalSkillModel nontechnicalskill)
        {
            this.name = name;
            this.associateid = associateid;
            this.mobile = mobile;
            this.email = email;
            this.technicalskill = technicalskill;
            this.nontechnicalskill = nontechnicalskill;
        }

        public string name { get; set; }
        public string associateid { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }
        public TechnicalSkillModel technicalskill { get; set; }
        public NonTechnicalSkillModel nontechnicalskill { get; set; }
    }
}
