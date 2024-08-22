using Agent_rest.Dto;
using Agent_rest.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agent_rest.Controllers
{
    [Route("a[controller]")]
    [ApiController]
    public class AgentController(IAgentService agentService) : ControllerBase
    {
        [HttpPost("create")]
        public async Task<ActionResult> CreateAgent([FromBody]AgentDto agentDto)
        {
            try
            {
                await agentService.CreateAgentAsync(agentDto);
                return Created("Agent created", agentDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{id}/pin")]
        public async Task<ActionResult> AgentPin(AgentPinDto agentPin, int id)
        {
            try
            {
                await agentService.AgentPinAsync(agentPin, id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
