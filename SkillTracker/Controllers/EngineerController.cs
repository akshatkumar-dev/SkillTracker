using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkillTracker.Converters;
using SkillTracker.Dtos;
using SkillTracker.Model;
using SkillTracker.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillTracker.Controllers
{
    [Route("skill-tracker/api/v1/engineer")]
    [ApiController]
    public class EngineerController : ControllerBase
    {
        IProfileRepository repository;
        public EngineerController(IProfileRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public async Task<List<DisplayProfileDto>> GetAllEngineers()
        {
            return ConvertProfile.ConvertListOfProfile((await repository.GetProfileListAsync()));
        }

        [HttpGet]
        [Route("{userId}")]
        public async Task<ActionResult<DisplayProfileDto>> GetEngineer(Guid userId)
        {
            ProfileModel result = await repository.GetProfileAsync(userId);
            if(result == null)
            {
                return NotFound();
            }
            return ConvertProfile.ConvertSingleProfile(result);
        }

        [HttpPost]
        [Route("add-profile")]
        public ActionResult AddProfile(CreateProfileDto newProfile)
        {
            ProfileModel newModel = new ProfileModel(newProfile.name,
                newProfile.associateid,
                newProfile.mobile,
                newProfile.email,
                newProfile.technicalskill,
                newProfile.nontechnicalskill);
           repository.AddProfileAsync(newModel);
            return NoContent();
        }

        [HttpPut]
        [Route("update-profile/{userId}")]
        public async Task<ActionResult> UpdateProfile(Guid userId, UpdateProfileDto newProfile)
        {
            ProfileModel result = await repository.GetProfileAsync(userId);
            if(result == null)
            {
                return NotFound("User Id is not found");
            }

            if (result.LastUpdated.AddDays(10) > DateTimeOffset.UtcNow)
            {
                return NotFound("Wait 10 days before updating the profile again");
            }
            repository.UpdateProfileAsync(userId, newProfile);
            return NoContent();
        }

        [HttpDelete]
        [Route("delete-profile/{userId}")]
        public async Task<ActionResult> DeleteProfile(Guid userId)
        {
            ProfileModel result = await repository.GetProfileAsync(userId);
            if(result == null)
            {
                return NotFound("User id not found");
            }
            repository.DeleteProfileAsync(userId);
            return NoContent();
        }
    }
}
