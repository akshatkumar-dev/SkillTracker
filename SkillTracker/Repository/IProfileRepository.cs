using SkillTracker.Dtos;
using SkillTracker.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkillTracker.Repository
{
    public interface IProfileRepository
    {
        Task<List<ProfileModel>> GetProfileListAsync();
        Task<ProfileModel> GetProfileAsync(Guid id);
        void AddProfileAsync(ProfileModel newProfile);
        void UpdateProfileAsync(Guid id, UpdateProfileDto newProfile);
        void DeleteProfileAsync(Guid id);
        Task<List<ProfileModel>> FilterProfileAsync(string criteria, string criteriaValue);
    }
}