using SkillTracker.Constants;
using SkillTracker.Dtos;
using SkillTracker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillTracker.Converters
{
    public static class ConvertSkills
    {
        public static Dictionary<string,int> ConvertTechnicalSkill(TechnicalSkillModel profile)
        {
            Dictionary<string, int> temp = new Dictionary<string, int>
            {
                { StringConstants.HTML,profile.htmlcssjavascript },
                { StringConstants.ANGULAR,profile.angular },
                { StringConstants.REACT,profile.react},
                { StringConstants.ASP,profile.aspdotnetcore},
                { StringConstants.RESTFUL,profile.restful},
                { StringConstants.ENTITY,profile.entityframework},
                { StringConstants.GIT,profile.git},
                { StringConstants.DOCKER,profile.docker},
                { StringConstants.JENKINS,profile.jenkins},
                { StringConstants.AZURE,profile.azure},
            };
            return temp;
            //List<KeyValuePair<string, int>> technicalSkill = new List<KeyValuePair<string, int>>
            //{
            //    new KeyValuePair<string, int>(StringConstants.HTML,profile.htmlcssjavascript),
            //    new KeyValuePair<string, int>(StringConstants.ANGULAR,profile.angular),
            //    new KeyValuePair<string, int>(StringConstants.REACT,profile.react),
            //    new KeyValuePair<string, int>(StringConstants.ASP,profile.aspdotnetcore),
            //    new KeyValuePair<string, int>(StringConstants.RESTFUL,profile.restful),
            //    new KeyValuePair<string, int>(StringConstants.ENTITY,profile.entityframework),
            //    new KeyValuePair<string, int>(StringConstants.GIT,profile.git),
            //    new KeyValuePair<string, int>(StringConstants.DOCKER,profile.docker),
            //    new KeyValuePair<string, int>(StringConstants.JENKINS,profile.jenkins),
            //    new KeyValuePair<string, int>(StringConstants.AZURE,profile.azure),
            //};
            //return technicalSkill;

        }

        public static TechnicalSkillModel ConvertToTechnicalSkillModel(List<KeyValuePair<string, int>> technical)
        {
            TechnicalSkillModel technicalSkillModel = new TechnicalSkillModel();
            technical.ForEach(skill =>
            {
                string key = skill.Key;
                int value = skill.Value;
                if (key == StringConstants.HTML) { technicalSkillModel.htmlcssjavascript = value; }
                if (key == StringConstants.ANGULAR) { technicalSkillModel.angular = value; }
                if (key == StringConstants.REACT) { technicalSkillModel.react = value; }
                if (key == StringConstants.ASP) { technicalSkillModel.aspdotnetcore = value; }
                if (key == StringConstants.ENTITY) { technicalSkillModel.entityframework = value; }
                if (key == StringConstants.GIT) { technicalSkillModel.git = value; }
                if (key == StringConstants.DOCKER) { technicalSkillModel.docker = value; }
                if (key == StringConstants.JENKINS) { technicalSkillModel.jenkins = value; }
                if (key == StringConstants.AZURE) { technicalSkillModel.azure = value; }
                if (key == StringConstants.RESTFUL) { technicalSkillModel.restful = value; }
            });
            return technicalSkillModel;
        }

        public static NonTechnicalSkillModel ConvertToNonTechnicalSkillModel(List<KeyValuePair<string, int>> nontech)
        {
            NonTechnicalSkillModel nonTechSkill = new NonTechnicalSkillModel();
            nontech.ForEach(skill =>
            {
                string key = skill.Key;
                int value = skill.Value;
                if (key == StringConstants.SPOKEN) { nonTechSkill.spoken = value; }
                if (key == StringConstants.COMM) { nonTechSkill.communication = value; }
                if (key == StringConstants.APTI) { nonTechSkill.aptitude = value; }
            });
            return nonTechSkill;
        }
        public static List<KeyValuePair<string, int>> ConvertNonTechnicalSkill(CreateProfileDto profile)
        {
            List<KeyValuePair<string, int>> nonTechnicalSkill = new List<KeyValuePair<string, int>>
            {
                new KeyValuePair<string, int>(StringConstants.SPOKEN,profile.nontechnicalskill.spoken),
                new KeyValuePair<string, int>(StringConstants.COMM,profile.nontechnicalskill.communication),
                new KeyValuePair<string, int>(StringConstants.APTI,profile.nontechnicalskill.aptitude),
            };

            return nonTechnicalSkill;
        }
    }
}
