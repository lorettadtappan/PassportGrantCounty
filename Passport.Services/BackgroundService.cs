using Passport.Contracts;
using Passport.Data;
using Passport.Data.Entities;
using Passport.Models.BackgroundModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passport.Services
{
    public class BackgroundService : IBackgroundService
    {
        private readonly ApplicationDbContext _ctx;
        public BackgroundService()
        {
            _ctx = new ApplicationDbContext();
        }
        public bool Create(BackgroundCreateModel model)
        {
            var entity = new Background()
            {
                Name = model.Name,
                AdventureLog = model.AdventureLog
            };
            _ctx.Backgrounds.Add(entity);
            return _ctx.SaveChanges() == 1;
        }

        public bool Delete(int backgroundId)
        {
            var entity = _ctx.Backgrounds.Single(e => e.BackgroundId == backgroundId);
            if (entity != null)
            {
                _ctx.Backgrounds.Remove(entity);
            }
            return _ctx.SaveChanges() == 1;
        }

        public bool Edit(BackgroundUpdateModel model)
        {
            var entity = _ctx.Backgrounds.Single(e => e.BackgroundId == model.BackgroundId);
            if (entity != null)
            {
                entity.Name = model.Name;
                entity.AdventureLog = model.AdventureLog;
            };
            return _ctx.SaveChanges() == 1;
        }

        public IEnumerable<BackgroundListModel> GetAllBackgrounds()
        {
            var backgroundList = _ctx.Backgrounds.Select(e => new BackgroundListModel
            {
                BackgroundId = e.BackgroundId,
                Name = e.Name
            }).ToList();
            return backgroundList;
        }
        public BackgroundDetailModel GetBackgroundById(int backgroundId)
        {
            var entity = _ctx.Backgrounds.Single(e => e.BackgroundId == backgroundId);
            return new BackgroundDetailModel()
            {
                BackgroundId = entity.BackgroundId,
                Name = entity.Name,
                AdventureLog = entity.AdventureLog
            };
        }
    }
}