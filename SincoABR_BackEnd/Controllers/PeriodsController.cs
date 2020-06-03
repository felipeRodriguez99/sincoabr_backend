using SINCOABR_INFRASTRUCTURE.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SincoABR_BackEnd.Controllers
{
    [Route("api/[Controller]")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PeriodsController : ApiController
    {

        private readonly PeriodsService _PeriodsService;

        public PeriodsController()
        {
            _PeriodsService = new PeriodsService();
        }

        [Route("api/Periods/GetPeriod")]
        [HttpGet]
        public async Task<IHttpActionResult> Get ()
        {
            try
            {
                var result = await _PeriodsService.GetPeriods();

                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest("No existe periodos");
                }
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }



        }
    }
}
