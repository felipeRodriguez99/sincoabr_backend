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
    [Route ("api/[Controller]")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class StudentsController : ApiController
    {

        private readonly StudentsService _StudentsService;

        public StudentsController()
        {
            _StudentsService = new StudentsService();
        }

        [Route("api/Students/GetStudentByCode")]
        [HttpGet]
        public  async Task<IHttpActionResult> GetByCode (string code)
        {
            try
            {
                var result = await _StudentsService.getStudentByCode(code);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest("No existe el estudiante");
                }
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
            


        }

        [Route("api/Students/GetStudent")]
        [HttpGet]
        public async Task<IHttpActionResult> Get ()
        {
            try
            {
                var result = await _StudentsService.getStudents();

                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest("No existe estudiantes");
                }
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }



        }

        [Route("api/Students/CreateStudent")]
        [HttpPost]
        public async Task<IHttpActionResult> Create([FromBody]StudentModel model)
        {
            try
            {
                bool result = await _StudentsService.createStudent(model);

                if (result)
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

        [Route("api/Students/UpdateStudent")]
        [HttpPut]
        public async Task<IHttpActionResult> Put ([FromBody] StudentDOT model)
        {
            try
            {
                var result = await _StudentsService.updateStudent(model);

                if (result != null)
                {
                    return Ok("Los datos se actualizaron");
                }
                else
                {
                    return BadRequest("Los datos no se actualizaron");
                }

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [Route("api/Students/GetReport")]
        [HttpGet]
        public async Task<IHttpActionResult> GetReport()
        {
            try
            {
                var result = await _StudentsService.reportEstudent();

                if (result.Count > 0)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest("No hay reporte");
                }
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }



        }

    }
}
