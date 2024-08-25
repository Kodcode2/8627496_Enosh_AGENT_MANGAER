using Agent_rest.Model;
using Agent_rest.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agent_rest.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MissionController(IMissionService missionService) : ControllerBase
    {
        [HttpGet("get all")]
        public async Task<ActionResult<List<MissionModel>>> GetAllMissions() =>
            Ok(await missionService.GetAllMissionsAsync());


        [HttpGet("{id}")]
        public async Task<ActionResult<MissionModel>> GetMissionById([FromRoute] int id)
        {
            try
            {
                var missions = missionService.GetAllMissionsById(id);
                return Ok(missions);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpGet("Get all options")]
        public async Task<ActionResult<MissionModel>> FindMissionsProposal()
        {
            try
            {
                var options = missionService.MissionProposal();
                return Ok(options);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("Update status")]
        public async Task<ActionResult<MissionModel>> UpdateMissionStatus([FromRoute]int missionId)
        {
            try
            {
                var update = await missionService.UpdateMissionStatusAsync(missionId);
                return Ok(update);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpPut("Update locations")]
        public async Task<ActionResult<MissionModel>> UpdateMissionLocation([FromRoute]int missionId)
        {
            try
            {
                var update = await missionService.UpdateLocations(missionId);
                return Ok(update);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
