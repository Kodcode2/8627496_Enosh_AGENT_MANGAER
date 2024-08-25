using Agent_rest.Dto;
using Agent_rest.Model;

namespace Agent_rest.Service
{
    public interface IAgentService
    {
        Task<List<AgentModel>> GetAllAgentsAsync();
        Task<AgentModel?> FindAgentByIdAsync(int id);
        Task<AgentModel> CreateAgentAsync(AgentDto agentDto);
        Task<AgentModel> AgentPinAsync(int id, PinDto pinDto);
        Task<AgentModel> MoveAgentAsync(int id, MoveDto moveDto);
    }
}
