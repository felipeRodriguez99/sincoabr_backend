using SINCOABR_CONTEXT.Entities;
using SINCOABR_INFRASTRUCTURE.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Security.Cryptography;
using System.Web.Http.Cors;

namespace SincoABR_BackEnd.Controllers
{

    [Route("api/[Controller]")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UsersController : ApiController
    {

        private readonly UsersService _UsersService;

        public UsersController()
        {
            _UsersService = new UsersService();
        }

        [Route("api/Users/CreateUser")]
        [HttpPost]
        public async Task<IHttpActionResult> Create([FromBody]Users model)
        {
            try
            { 
                var result = await _UsersService.createUser(model);

                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest("No se pudo crear el usuario");
                }
                
                
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
