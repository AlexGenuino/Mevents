using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Route ("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {   

        private IUserService _service;
        public UsersController (IUserService service) 
        {
            _service = service;
        }
        [Authorize("Bearer")]
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                 return Ok (await _service.GetAll());
            }
            catch (ArgumentException e)
            {
                
                return StatusCode ((int) HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize("Bearer")]
        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route ("{id}", Name = "GetById")]
        public async Task<ActionResult> Get (Guid id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                 return Ok (await _service.Get(id));
            }
            catch (ArgumentException e)
            { 
                return StatusCode ((int) HttpStatusCode.InternalServerError, e.Message);
            }   

        }
        
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Post ([FromBody] UserEntity user)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                 var result = await _service.Post(user);
                 if(result != null)
                 {
 
                     return Ok(result);
                 }
                 else
                 {
                    return BadRequest();
                 }
            }
            catch (ArgumentException e)
            { 
                return StatusCode ((int) HttpStatusCode.InternalServerError, e.Message);
            }   

        }

        [Authorize("Bearer")]
        [Authorize(Roles = "Usuario")]
        [HttpPut]
        public async Task<ActionResult> Put ([FromBody] UserEntity user)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                 var result = await _service.Put(user);
                 if(result != null)
                 {
                    return Ok(result);
                 }
                 else
                 {
                    return BadRequest();
                 }
            }
            catch (ArgumentException e)
            { 
                return StatusCode ((int) HttpStatusCode.InternalServerError, e.Message);
            }   

        }

        [Authorize("Bearer")]
        [Authorize(Roles = "Admin")]
        [HttpDelete ("{id}")]
        public async Task<ActionResult> Delete (Guid id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                 return Ok(await _service.Delete(id));
            }
            catch (ArgumentException e)
            { 
                return StatusCode ((int) HttpStatusCode.InternalServerError, e.Message);
            }   

        }
    }
}
