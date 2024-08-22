using Agent_rest.Dto;
using Agent_rest.Model;

namespace Agent_rest.Service
{
    public interface ITargetService
    {
        Task<TargetModel> GetTargetsAsync(TargetGetDto getDto);
        Task<TargetModel?> GetTargetByIdAsync(int id);
        Task<TargetModel> CreateTargetAsync(TargetDto targetDto);
    }
}
