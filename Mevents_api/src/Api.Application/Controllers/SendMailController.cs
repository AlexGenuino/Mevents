using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Services.SendEmail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendMailController : ControllerBase
    {
        
            [AllowAnonymous]
            [HttpPost]
            public async Task<object> SendMail([FromBody] ModelSend Send)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (Send == null)
                {
                    return BadRequest();
                }
                try
                {
                    SendMail NewMail = new SendMail();

                    var result = await NewMail.Send(Send);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (ArgumentException e)
                {

                    return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
                }
            }
        }
    
}
