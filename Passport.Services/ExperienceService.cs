using Passport.Contracts;
using Passport.Data;
using Passport.Data.Entities;
using Passport.Models.ExperienceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passport.Services
{
    public class ExperienceService : IExperienceService
    {
        private readonly ApplicationDbContext _ctx;
        public ExperienceService()
        {
            _ctx = new ApplicationDbContext();
        }
        public bool Create(ExperienceCreateModel model)
        {
            var entity = new Experience()
            {
                Name = model.Name,
                ChallengeScoreIncrease = model.ChallengeScoreIncrease,
                RoadMaps = model.RoadMaps,
                Comments = model.Comment,
            };
            _ctx.Experiences.Add(entity);
            return _ctx.SaveChanges() == 1;
        }

        public bool Delete(int experienceId)
        {
            var entity = _ctx.Experiences.Single(e => e.ExperienceId == experienceId);
            if (entity != null)
            {
                _ctx.Experiences.Remove(entity);
            }
            return _ctx.SaveChanges() == 1;
        }

        public bool Edit(ExperienceUpdateModel model)
        {
            var entity = _ctx.Experiences.Single(e => e.ExperienceId == model.ExperienceId);
            if (entity != null)
            {
                entity.Name = model.Name;
                entity.ChallengeScoreIncrease = model.ChallengeScoreIncrease;
                entity.RoadMaps = model.RoadMaps;
                entity.Comments = model.Comment;
            }
            return _ctx.SaveChanges() == 1;
        }

        public IEnumerable<ExperienceListModel> GetAllExperiences()
        {
            var experienceList = _ctx.Experiences.Select(e => new ExperienceListModel
            {
                ExperienceId = e.ExperienceId,
                Name = e.Name
            }).ToList();
            return experienceList;
        }

        public ExperienceDetailModel GetExperienceDetailById(int experienceId)
        {
            var entity = _ctx.Experiences.Single(e => e.ExperienceId == experienceId);
            var model = new ExperienceDetailModel
            {
                ExperienceId = entity.ExperienceId,
                Name = entity.Name,
                ChallengeScoreIncrease = entity.ChallengeScoreIncrease,
            };
            return model;
        }

        public ExperienceDetailViewModel GetExperienceDetailViewById(int experienceId)
        {
            var entity = _ctx.Experiences.Single(e => e.ExperienceId == experienceId);
            var model = new ExperienceDetailViewModel
            {
                ExperienceId = entity.ExperienceId,
                Name = entity.Name,
                ChallengeScoreIncrease = entity.ChallengeScoreIncrease,
            };
            return model;
        }

        public string FormatChallengeScoreIncrease(Experience entity)
        {
            string formattedChallengeScoreIncrease = "";
            string challenge = "";
            string bonus = "";
            foreach (var kvp in entity.ChallengeScoreIncrease)
            {
                challenge = kvp.Key.ToString() + " ";
                if (kvp.Value.Contains('+') || kvp.Value.Contains('-'))
                {
                    bonus = kvp.Value + " ";
                }
                else
                {
                    bonus = $"+{kvp.Value} ";
                }
                formattedChallengeScoreIncrease += challenge + bonus;
            }
            return formattedChallengeScoreIncrease;
        }

    }
}