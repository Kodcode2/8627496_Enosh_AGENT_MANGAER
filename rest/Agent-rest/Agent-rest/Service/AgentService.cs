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
        // פונקצייה שמביאה את כל הסוכנים
        public async Task<List<AgentModel>> GetAllAgentsAsync() =>
            await context.Agents.ToListAsync();


        // פונקצייה שמביאה סוכן ע"פ איי די
        public async Task<AgentModel?> FindAgentByIdAsync(int id) =>
            await context.Agents.Include(agent => agent.OptionalTargets)
            .FirstOrDefaultAsync(agent => agent.Id == id);



        // פונקצייה שיוצרת סוכן חדש
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



        // פונקצייה שיוצרת מיקום לסוכן
        public async Task<AgentModel> AgentPinAsync(int id, PinDto pinDto)
        {
            if (pinDto == null)
            { throw new Exception("You cannot create an empty pin agent"); }

            AgentModel? findById = await FindAgentByIdAsync(id);
            findById.Location_X = pinDto.X;
            findById.Location_Y = pinDto.Y;

            var isValid = AgentPinValid(findById);
            if (!isValid) { throw new Exception("The new location is out of range"); }
            await context.SaveChangesAsync();
            return findById;
        }



        // פונקצייה שמזיזה את הסוכן
        public async Task<AgentModel> MoveAgentAsync(int id, MoveDto moveDto)
        {
            var agent = await FindAgentByIdAsync(id);

            if (agent.Status == AgentStatus.Active) { throw new Exception("can't be moved Agent in action"); }
            var move = Move(moveDto);

            agent.Location_X += move.Item1;
            agent.Location_Y += move.Item2;

            var isValid = AgentPinValid(agent);
            if (!isValid) { throw new Exception($"cannot be moved foreign agent to the borders the matrix {agent.Location_X}, {agent.Location_Y}"); }

            await context.SaveChangesAsync();
            return agent;
        }
    }
}