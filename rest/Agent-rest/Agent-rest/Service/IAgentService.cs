using Agent_rest.Dto;
using Agent_rest.Model;

namespace Agent_rest.Service
{
    public interface IAgentService
    {
        Task<List<AgentModel>> GetAgentsAsync();
        Task<AgentModel?> FindAgentByIdAsync(int id);
        Task<AgentModel> CreateAgentAsync(AgentDto agentDto);
        Task<AgentModel> AgentPinAsync(AgentPinDto pinDto, int id);
    }
}
