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
    public class TeachersController : ApiController
    {
        private readonly TeachersService _TeachersService;
        private readonly UsersService _UsersService;

        public TeachersController()
        {
            _TeachersService = new TeachersService();
            _UsersService = new UsersService();
            
        }

        [Route("api/Teachers/CreateTeacher")]
        [HttpPost]
        public async Task<IHttpActionResult> Create([FromBody]TeachersModel model)
        {
            try
            {

                var result = await _TeachersService.createTeacher(model);

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

        [Route("api/Teachers/GetTeacherByCode")]
        [HttpGet]
        public async Task<IHttpActionResult> GetaTeacherByCode (string code)
        {
            try
            {

                var result = await _TeachersService.GetTeacherByCode(code);

                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest("No existe el profesor");
                }

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [Route("api/Teachers/GetTeacher")]
        [HttpGet]
        public async Task<IHttpActionResult> GetaTeacher ()
        {
            try
            {

                var result = await _TeachersService.GetTeachers();

                if (result.Count > 0)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest("No existen profesores");
                }

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [Route("api/Teachers/CreateTeacherSubject")]
        [HttpPost]
        public async Task<IHttpActionResult> CreateTechaerSubject ([FromBody]Teachers_SubjectsDOT model)
        {
            try
            {

                var result = await _TeachersService.CreateTeachers_Subjects(model);

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

        [Route("api/Teachers/GetTeacherSubject")]
        [HttpGet]
        public async Task<IHttpActionResult> GetTeacherSubject (string code)
        {
            try
            {

                var result = await _TeachersService.GetTeachers_Subjects(code);

                if (result != null)
                {
                    return Ok(result);
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

        [Route("api/Teachers/DeleteTeacher")]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteTeacher (string code)
        {
            try
            {

                var result = await _TeachersService.GetTeacherByCode(code);
              
                if (result != null)
                {
                    var resul1 = await _UsersService.getUser(result.email);
                    resul1.state = false;
                    var resul2 = await _UsersService.updateUser(resul1);
                    if (true)
                    {
                        return Ok("Se elimino correctamente");
                    }
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
