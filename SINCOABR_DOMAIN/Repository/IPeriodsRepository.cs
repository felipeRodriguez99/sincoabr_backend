﻿using SINCOABR_CONTEXT.Entities;
using SINCOABR_CONTEXT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SINCOABR_DOMAIN.Repository
{
    public interface IPeriodsRepository
    {
        Task<List<Periods>> GetPeriods();        
    }
}
