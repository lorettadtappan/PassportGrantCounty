using Passport.Models.RoadMapModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passport.Contracts
{
    public interface IRoadMapService
    {
        bool Create(RoadMapCreateModel model);
        bool Edit(RoadMapUpdateModel model);
        bool Delete(int roadMapId);
        IEnumerable<RoadMapListModel> GetAllRoadMaps();
        RoadMapDetailModel GetRoadMapDetailById(int roadMapId);
        RoadMapDetailViewModel GetRoadMapDetailViewById(int roadMapId);
    }
}
