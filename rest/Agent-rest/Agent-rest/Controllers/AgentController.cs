using Agent_rest.Dto;
using Agent_rest.Model;
using Agent_rest.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agent_rest.Controllers
{
    [Route("a[controller]")]
    [ApiController]
    public class AgentController(IAgentService agentService) : ControllerBase
    {
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<AgentModel>>> GetUsers() =>
            Ok(await agentService.GetAllAgentsAsync());



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
        public async Task<ActionResult> AgentPin([FromRoute] int id, [FromBody]PinDto agentPin)
        {
            try
            {
                await agentService.AgentPinAsync(id, agentPin);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{id}/move")]
        public async Task<ActionResult> MoveAgent([FromRoute]int id, [FromBody]MoveDto moveDto)
        {
            try
            {
                await agentService.MoveAgentAsync(id, moveDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
