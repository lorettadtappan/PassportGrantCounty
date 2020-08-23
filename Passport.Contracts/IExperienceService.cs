using Passport.Models.ExperienceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passport.Contracts
{
    public interface IExperienceService
    {
        bool Create(ExperienceCreateModel model);
        bool Edit(ExperienceUpdateModel model);
        bool Delete(int experienceId);
        IEnumerable<ExperienceListModel> GetAllExperiences();
        ExperienceDetailModel GetExperienceDetailById(int experienceId);
        ExperienceDetailViewModel GetExperienceDetailViewById(int experienceId);
    }
}