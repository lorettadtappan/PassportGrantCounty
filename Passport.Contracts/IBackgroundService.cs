using Passport.Models.BackgroundModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passport.Contracts
{
    public interface IBackgroundService
    {
        bool Create(BackgroundCreateModel model);
        bool Edit(BackgroundUpdateModel model);
        bool Delete(int BackgroundId);
        IEnumerable<BackgroundListModel> GetAllBackgrounds();
        BackgroundDetailModel GetBackgroundById(int BackgrounId);
    }
}
