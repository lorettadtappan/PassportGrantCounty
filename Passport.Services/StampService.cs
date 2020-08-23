using Passport.Contracts;
using Passport.Data;
using Passport.Models.StampModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passport.Services
{
    public class StampService : IStampService
    {
        private readonly ApplicationDbContext _ctx;
        public StampService()
        {
            _ctx = new ApplicationDbContext();
        }
        public IEnumerable<StampListModel> GetAllStamps()
        {
            var stampList = _ctx.Stamps
                .Where(e => e.IsDeleted == false)
                .Select(e => new StampListModel
                {
                    StampId = e.StampId,
                    Explorer = _ctx.Users.FirstOrDefault(u => u.Id == e.OwnerId.ToString()).UserName,
                    Name = e.Name,
                    StampLevel = e.StampLevel,
                }).ToList();
            return stampList;
        }

        public StampDetailViewModel GetStampDetailViewById(int stampId)
        {
            var entity = _ctx.Stamps.Single(e => e.StampId == stampId);
            var model = new StampDetailViewModel
            {
                StampId = entity.StampId,
                Explorer = _ctx.Users.FirstOrDefault(u => u.Id == entity.OwnerId.ToString()).UserName,
                Name = entity.Name,
                StampLevel = GetStampLevelForDetail(entity.StampLevel),
            };
            return model;
        }
        private string GetStampLevelForDetail(int level)
        {
            switch (level)
            {
                case 0:
                    return "StartCollecting";
                case 1:
                    return "1st-level";
                case 2:
                    return "2nd-level";
                case 3:
                    return "3rd-level";
                case 4:
                    return "4th-level";
                case 5:
                    return "5th-level";
                case 6:
                    return "6th-level";
                case 7:
                    return "7th-level";
                case 8:
                    return "8th-level";
                case 9:
                    return "9th-level";
                case 10:
                    return "10th-level";
                case 11:
                    return "11th-level";
                case 12:
                    return "12th-level";
                case 13:
                    return "13th-level";
                case 14:
                    return "14th-level";
                case 15:
                    return "15th-level";
                case 16:
                    return "16th-level";
                case 17:
                    return "17th-level";
                case 18:
                    return "18th-level";
                case 19:
                    return "19th-level";
                case 20:
                    return "20th-level";
                case 21:
                    return "21st-level";
                case 22:
                    return "22nd-level";
                case 23:
                    return "23rd-level";
                case 24:
                    return "24th-level";
                default:
                    return "unknown level";
            }
        }
    }
}