using Agent_rest.Dto;
using Agent_rest.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agent_rest.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TargetController(ITargetService targetService) : ControllerBase
    {
        [HttpPost("create")]
        public async Task<ActionResult> CreateTarget([FromBody] TargetDto targetDto)
        {
            try
            {
                await targetService.CreateTargetAsync(targetDto);
                return Created("Agent created", targetDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
