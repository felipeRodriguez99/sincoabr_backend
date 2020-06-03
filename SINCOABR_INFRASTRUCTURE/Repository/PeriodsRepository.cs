using SINCOABR_CONTEXT.Context;
using SINCOABR_CONTEXT.Entities;
using SINCOABR_CONTEXT.Models;
using SINCOABR_DOMAIN.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SINCOABR_INFRASTRUCTURE.Repository
{
    public class PeriodsRepository : IPeriodsRepository
    {
        public async Task<List<Periods>> GetPeriods()
        {
            try
            {
                using (var context = new SincoABRContext())
                {
                    var subjects = await context.Periods.ToListAsync();

                    List<Periods> periodstList = new List<Periods>();

                    foreach (var item in subjects)
                    {
                        Periods period = new Periods();

                        period.periodId = item.periodId;
                        period.name = item.name;
                        periodstList.Add(period);
                    }

                    return periodstList;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
