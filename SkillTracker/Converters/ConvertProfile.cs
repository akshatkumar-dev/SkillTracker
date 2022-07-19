using SkillTracker.Dtos;
using SkillTracker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillTracker.Converters
{
    public static class ConvertProfile
    {
        public static DisplayProfileDto ConvertSingleProfile(ProfileModel profileModel)
        {
            DisplayProfileDto displayProfileDto = new DisplayProfileDto(
                profileModel.Name, profileModel.AssociateId, profileModel.Mobile, profileModel.Email,
                profileModel.TechnicalSkill,
                profileModel.NonTechnicalSkill,
                profileModel.CreatedDate,
                profileModel.LastUpdated,
                profileModel.UserId);
            return displayProfileDto;
        }

        public static List<DisplayProfileDto> ConvertListOfProfile(List<ProfileModel> profileModels)
        {
            List<DisplayProfileDto> displayProfileDtos = new List<DisplayProfileDto>();
            profileModels.ForEach(model =>
            {
                displayProfileDtos.Add(ConvertSingleProfile(model));
            });
            return displayProfileDtos;
        }
    }
}
