using Agent_rest.Dto;
using Agent_rest.Model;

namespace Agent_rest.Service
{
    public interface ITargetService
    {
        Task<List<TargetModel>> GetAllTargetsAsync();
        Task<TargetModel?> GetTargetByIdAsync(int id);
        Task<TargetModel> CreateTargetAsync(TargetDto targetDto);
        Task<TargetModel> TargetPinAsync(int id, PinDto pinDto);
        Task<TargetModel> MoveTargetAsync(int id, MoveDto moveDto);
    }
}
