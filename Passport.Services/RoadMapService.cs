using Passport.Contracts;
using Passport.Data;
using Passport.Data.Entities;
using Passport.Models.RoadMapModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passport.Services
{
    public class RoadMapService : IRoadMapService
    {
        private readonly ApplicationDbContext _ctx;
        public RoadMapService()
        {
            _ctx = new ApplicationDbContext();
        }
        public bool Create(RoadMapCreateModel model)
        {
            var entity = new RoadMap()
            {
                Name = model.Name,
                Speed = model.Speed,
                IsActive = model.IsActive,
                ChallengeScoreIncrease = model.ChallengeScoreIncrease,
                Experiences = model.Experiences,
                Comments = model.Comments,
            };
            _ctx.RoadMaps.Add(entity);
            return _ctx.SaveChanges() == 1;
        }

        public bool Delete(int roadMapId)
        {
            var entity = _ctx.RoadMaps.Single(e => e.RoadMapId == roadMapId);
            if (entity != null)
            {
                _ctx.RoadMaps.Remove(entity);
            }
            return _ctx.SaveChanges() == 1;
        }

        public bool Edit(RoadMapUpdateModel model)
        {
            var entity = _ctx.RoadMaps.Single(e => e.RoadMapId == model.RoadMapId);
            if (entity != null)
            {
                entity.Name = model.Name;
                entity.Speed = model.Speed;
                entity.IsActive = model.IsActive;
                entity.ChallengeScoreIncrease = model.ChallengeScoreIncrease;
                entity.Experiences = model.Experiences;
                entity.Comments = model.Comments;
            }
            return _ctx.SaveChanges() == 1;
        }

        public IEnumerable<RoadMapListModel> GetAllRoadMaps()
        {
            var roadMapList = _ctx.RoadMaps.Select(e => new RoadMapListModel
            {
                RoadMapId = e.RoadMapId,
                Name = e.Name
            }).ToList();
            return roadMapList;
        }

        public RoadMapDetailModel GetRoadMapDetailById(int roadMapId)
        {
            var entity = _ctx.RoadMaps.Single(e => e.RoadMapId == roadMapId);
            var model = new RoadMapDetailModel
            {
                RoadMapId = entity.RoadMapId,
                Name = entity.Name,
                Speed = entity.Speed,
                IsActive = entity.IsActive,
                ChallengeScoreIncrease = entity.ChallengeScoreIncrease,
                Experiences = entity.Experiences,
            };
            return model;
        }
        public RoadMapDetailViewModel GetRoadMapDetailViewById(int roadMapId)
        {
            var entity = _ctx.RoadMaps.Single(e => e.RoadMapId == roadMapId);
            var model = new RoadMapDetailViewModel
            {
                RoadMapId = entity.RoadMapId,
                Name = entity.Name,
                Speed = entity.Speed,
                IsActive = entity.IsActive,
                ChallengeScoreIncrease = entity.ChallengeScoreIncrease,
                Experiences = entity.Experiences,
            };
            return model;
        }
        public string FormatChallengeScoreIncrease(RoadMap entity)
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