using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillTracker.Model
{
    [BsonIgnoreExtraElements]
    public class ProfileModel
    {
        public ProfileModel(string name, string associateId, string mobile, string email, TechnicalSkillModel technicalskill, NonTechnicalSkillModel nontechnicalskill)
        {
            Name = name;
            AssociateId = associateId;
            Mobile = mobile;
            Email = email;
            TechnicalSkill = technicalskill;
            NonTechnicalSkill = nontechnicalskill;
            CreatedDate = DateTimeOffset.UtcNow;
            LastUpdated = CreatedDate;
            UserId = Guid.NewGuid();

        }

        public string Name { get; set; }
        public string AssociateId { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public TechnicalSkillModel TechnicalSkill { get; set; }
        public NonTechnicalSkillModel NonTechnicalSkill { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset LastUpdated { get; set; }
        public Guid UserId { get; set; }
    }
}
