using SINCOABR_CONTEXT.Entities;
using SINCOABR_CONTEXT.Models;
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
    public class NotesController : ApiController
    {
        private readonly NotesService _NotesService;

        public NotesController()
        {
            _NotesService = new NotesService();
        }

        [Route("api/Notes/CreateNote")]
        [HttpPost]
        public async Task<IHttpActionResult> Create([FromBody] NotesDOT model)
        {
            try
            {

                var result = await _NotesService.CreateNote(model);

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

        [Route("api/Notes/GetNote")]
        [HttpGet]
        public async Task<IHttpActionResult> Get (string code)
        {
            try
            {

                var result = await _NotesService.GetNote(code);

                if (result.Count > 0)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest("No exiten materias asignadas al usuario");
                }

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [Route("api/Notes/UpdateNote")]
        [HttpPut]
        public async Task<IHttpActionResult> Put ([FromBody] NotesDOT model)
        {
            try
            {

                var result = await _NotesService.UpdateeNote(model);

                if (result != null)
                {
                    return Ok("Se acualizo correctamente");
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
