using SkillTracker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillTracker.Dtos
{
    public class UpdateProfileDto
    {
        public UpdateProfileDto(TechnicalSkillModel technicalskill, NonTechnicalSkillModel nontechnicalskill)
        {
            this.technicalskill = technicalskill;
            this.nontechnicalskill = nontechnicalskill;
        }

        public TechnicalSkillModel technicalskill { get; set; }
        public NonTechnicalSkillModel nontechnicalskill { get; set; }
    }
}
