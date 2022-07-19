using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using SkillTracker.Model;
using SkillTracker.Dtos;
using SkillTracker.Constants;
using SkillTracker.Converters;

namespace SkillTracker.Repository
{
    public class MongoRepository : IProfileRepository
    {
        MongoClient client;
        IMongoDatabase database;
        IMongoCollection<ProfileModel> collection;
        public MongoRepository()
        {
            client = new MongoClient(
                "mongodb+srv://admin:<password>@cluster0.0teetsc.mongodb.net/?retryWrites=true&w=majority");
            database = client.GetDatabase("Engineer");
            collection = database.GetCollection<ProfileModel>("Profiles");
        }

        public async Task<List<ProfileModel>> GetProfileListAsync()
        {
            return (await collection.FindAsync(_ => true)).ToList();
        }
        public async Task<ProfileModel> GetProfileAsync(Guid id)
        {
            try
            {
                var result = (await collection.FindAsync(profile => profile.UserId == id)).Single();
                return result;
            }
            catch(Exception _)
            {
                return null;
            }
        }
        public async void AddProfileAsync(ProfileModel newProfile)
        { 
            await collection.InsertOneAsync(newProfile);
        }

        public async void UpdateProfileAsync(Guid id, UpdateProfileDto newProfile)
        {
            var filter = Builders<ProfileModel>.Filter.Eq("UserId", id);
            var update = Builders<ProfileModel>.Update.Combine(Builders<ProfileModel>.Update.Set("TechnicalSkill", newProfile.technicalskill),
                Builders<ProfileModel>.Update.Set("NonTechnicalSkill", newProfile.nontechnicalskill));
           await collection.UpdateOneAsync(filter, update);
            
        }

        public async void DeleteProfileAsync(Guid id)
        {
            try
            {
               await collection.DeleteOneAsync(profile => profile.UserId == id);
            }
            catch(Exception _)
            {
                
            }
        }

        public async Task<List<ProfileModel>> FilterProfileAsync(string criteria, string criteriaValue)
        {
            criteria = criteria.ToLower();
            criteriaValue = criteriaValue.ToLower();
            if(criteria == StringConstants.NAME)
            {
                return (await collection.FindAsync(profile => profile.Name.ToLower().StartsWith(criteriaValue))).ToList();
            }
            else if(criteria == StringConstants.SKILL)
            {
                if(criteriaValue == StringConstants.ANGULAR)
                {
                    return (await collection.FindAsync(profile => profile.TechnicalSkill.angular > 10)).ToList();
                }
                if (criteriaValue == StringConstants.HTML)
                {
                    return (await collection.FindAsync(profile => profile.TechnicalSkill.htmlcssjavascript > 10)).ToList();
                }
                if (criteriaValue == StringConstants.REACT)
                {
                    return (await collection.FindAsync(profile => profile.TechnicalSkill.react > 10)).ToList();
                }
                if (criteriaValue == StringConstants.ASP)
                {
                    return (await collection.FindAsync(profile => profile.TechnicalSkill.aspdotnetcore > 10)).ToList();
                }
                if (criteriaValue == StringConstants.RESTFUL)
                {
                    return (await collection.FindAsync(profile => profile.TechnicalSkill.restful > 10)).ToList();
                }
                if (criteriaValue == StringConstants.ENTITY)
                {
                    return (await collection.FindAsync(profile => profile.TechnicalSkill.entityframework > 10)).ToList();
                }
                if (criteriaValue == StringConstants.GIT)
                {
                    return (await collection.FindAsync(profile => profile.TechnicalSkill.git > 10)).ToList();
                }
                if (criteriaValue == StringConstants.DOCKER)
                {
                    return (await collection.FindAsync(profile => profile.TechnicalSkill.docker > 10)).ToList();
                }
                if (criteriaValue == StringConstants.JENKINS)
                {
                    return (await collection.FindAsync(profile => profile.TechnicalSkill.jenkins > 10)).ToList();
                }
                if (criteriaValue == StringConstants.AZURE)
                {
                    return (await collection.FindAsync(profile => profile.TechnicalSkill.azure > 10)).ToList();
                }
                if (criteriaValue == StringConstants.SPOKEN)
                {
                    return (await collection.FindAsync(profile => profile.NonTechnicalSkill.spoken > 10)).ToList();
                }
                if (criteriaValue == StringConstants.COMM)
                {
                    return (await collection.FindAsync(profile => profile.NonTechnicalSkill.communication > 10)).ToList();
                }
                if (criteriaValue == StringConstants.APTI)
                {
                    return (await collection.FindAsync(profile => profile.NonTechnicalSkill.aptitude > 10)).ToList();
                }
                return new List<ProfileModel>();
            }
            else if(criteria == StringConstants.ID)
            {
                return (await collection.FindAsync(profile => profile.AssociateId.ToLower() == criteriaValue)).ToList();
            }
            return null;
        }
    }
}
