using Agent_rest.Data;
using Agent_rest.Dto;
using Agent_rest.Model;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using static Agent_rest.Utils.Utilities;

namespace Agent_rest.Service
{
    public class AgentService(ApplicationDbContext context) : IAgentService
    {
        public async Task<List<AgentModel>> GetAgentsAsync() =>
            await context.Agents.Include(agent => agent.OptionalTargets).ToListAsync();


        public async Task<AgentModel?> FindAgentByIdAsync(int id) =>
            await context.Agents.Include(agent => agent.OptionalTargets)
            .FirstOrDefaultAsync(agent => agent.Id == id);


        public async Task<AgentModel> CreateAgentAsync(AgentDto agent)
        {
            if (agent == null) 
            { throw new Exception("You cannot create an empty agent"); }

            AgentModel agentModel = new AgentModel()
            {
                Nickname = agent.Nickname,
                Image = agent.PhotoUrl,
            };
            await context.Agents.AddAsync(agentModel);
            await context.SaveChangesAsync();
            return agentModel;
        }



        public async Task<AgentModel> AgentPinAsync(AgentPinDto pinDto, int id)
        {
            if (pinDto == null)
            { throw new Exception("You cannot create an empty pin agent"); }

            var isValid = PinValid(pinDto);

            if (!isValid) { throw new Exception("The new location is out of range"); }

            AgentModel? findById = await FindAgentByIdAsync(id);
            findById.Id = id;
            findById.Image = findById.Image;
            findById.Status = findById.Status;
            findById.Nickname = findById.Nickname;
            findById.Location_X = pinDto.x;
            findById.Location_Y = pinDto.y;
            await context.SaveChangesAsync();
            return findById;
        }



    }
}
