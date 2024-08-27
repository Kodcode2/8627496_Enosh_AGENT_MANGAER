using Agent_rest.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agent_rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculationsController(ICalculationsService calculations) : ControllerBase
    {
        [HttpGet("agents")]
        public async Task<ActionResult> SumAllAgents()
        {
            var sumAgents = await calculations.SumAgents();
            return Ok(sumAgents);
        }


        [HttpGet("targets")]
        public async Task<ActionResult> SumTarget()
        {
            var sumTargets = await calculations.SumTargets();
            return Ok(sumTargets);
        }

        [HttpGet("missions")]
        public async Task<ActionResult> SumMissions()
        {
            var sumMissions = await calculations.SumMissions();
            return Ok(sumMissions);
        }


        [HttpGet("ratio")]
        public async Task<ActionResult> AttitudeOfAgentsToMissions()
        {
            var sumAgents = await calculations.SumAgents();
            var sumMissions = await calculations.SumMissions();
            var ratio = calculations.GetRatio(sumAgents.sum, sumMissions.sum);
            return Ok(ratio);
        }



        [HttpGet("optional ratio")]
        public async Task<ActionResult> RatioOfOptionalAgentsToMissions()
        {

            var sumMissions = await calculations.SumMissions();
            var ratio = calculations.GetRatio(sumMissions.pro, sumMissions.sum);
            return Ok(ratio);
        }
    }
}
