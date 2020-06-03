using SINCOABR_CONTEXT.Entities;
using SINCOABR_CONTEXT.Models;
using SINCOABR_DOMAIN.Service;
using SINCOABR_INFRASTRUCTURE.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SINCOABR_INFRASTRUCTURE.Service
{
    public class PeriodsService : IPeriodsService
    {
        private readonly PeriodsRepository _PeriodsRepository;
        public PeriodsService()
        {
            _PeriodsRepository = new PeriodsRepository();
        }

        public async Task<List<Periods>> GetPeriods()
        {
            return await _PeriodsRepository.GetPeriods();
        }
    }
}
