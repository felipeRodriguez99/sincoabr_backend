using SINCOABR_CONTEXT.Entities;
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
    public class SubjectsController : ApiController
    {
        private readonly SubjectsService _SubjectsService;

        public SubjectsController()
        {
            _SubjectsService = new SubjectsService();
        }

        [Route("api/Subject/GetSubject")]
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var result = await _SubjectsService.getSubjects();

                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest("No existe materias");
                }
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }



        }

        [Route("api/Subject/CreateSubject")]
        [HttpPost]
        public async Task<IHttpActionResult> Create ([FromBody] Subjects model)
        {
            try
            {
                var result = await _SubjectsService.createSubjects(model);

                if (result != null)
                {
                    return Ok("Se creo correctamente");
                }
                else
                {
                    return BadRequest("No se pudo crear");
                }

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
