﻿using Passport.Models.StampModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passport.Contracts
{
    public interface IStampService
    {
        IEnumerable<StampListModel> GetAllStamps();
        StampDetailViewModel GetStampDetailViewById(int stampId);
    }
}