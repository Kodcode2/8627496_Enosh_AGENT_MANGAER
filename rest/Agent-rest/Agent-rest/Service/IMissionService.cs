using Agent_rest.Model;

namespace Agent_rest.Service
{
    public interface IMissionService
    {
        Task<List<MissionModel>> GetAllMissionsAsync();
        List<MissionModel> GetAllMissionsById(int id);
        List<MissionModel> MissionProposal();
        Task<MissionModel> UpdateMissionStatusAsync(int missionId);
        Task<MissionModel> UpdateLocations(int missionId);
    }
}
