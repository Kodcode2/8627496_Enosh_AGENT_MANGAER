using Agent_rest.Dto;
using Agent_rest.Model;
using Agent_rest.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agent_rest.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class targetsController(ITargetService targetService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> Gettargets()
        {
            try
            {
                await targetService.GetAllTargetsAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpPost]
        public async Task<ActionResult> CreateTarget([FromBody] TargetDto targetDto)
        {
            try
            {
                var target = await targetService.CreateTargetAsync(targetDto);
                return Created("Agent created", target);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpPut("{id}/pin")]
        public async Task<ActionResult> TargetPin([FromRoute] int id, [FromBody] PinDto pinDto)
        {
            try
            {
                await targetService.TargetPinAsync(id, pinDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




        [HttpPut("{id}/move")]
        public async Task<ActionResult> MoveTarget([FromRoute] int id, [FromBody] MoveDto moveDto)
        {
            try
            {
                await targetService.MoveTargetAsync(id, moveDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
