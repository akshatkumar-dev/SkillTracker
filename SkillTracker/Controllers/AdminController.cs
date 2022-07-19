using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkillTracker.Dtos;
using SkillTracker.Model;
using SkillTracker.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillTracker.Controllers
{
    [Route("skill-tracker/api/v1/admin/")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        IProfileRepository repository;
        public AdminController(IProfileRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        [Route("{criteria}/{criteriaValue}")]
        public async Task<ActionResult<List<FilterProfileDto>>> GetFilteredProfiles(string criteria, string criteriaValue)
        {
            criteria = criteria.ToLower();
            List<ProfileModel> filtered = await repository.FilterProfileAsync(criteria, criteriaValue);
            if(filtered == null)
            {
                return NotFound("criteria not in database");
            }
            List<FilterProfileDto> newList = new List<FilterProfileDto>();
            filtered.ForEach(profile => newList.Add(new FilterProfileDto(profile.Name, profile.AssociateId, profile.Mobile, profile.Email, profile.TechnicalSkill, profile.NonTechnicalSkill)));
            return newList;
        }
    }
}
