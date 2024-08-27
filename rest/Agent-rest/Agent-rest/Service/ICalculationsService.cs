namespace Agent_rest.Service
{
    public interface ICalculationsService
    {
        Task<(int sum, int act)> SumAgents();
        Task<(int sum, int kill)> SumTargets();
        Task<(int sum, int act, int pro)> SumMissions();
        double GetRatio(int numerator, int denominator);
    }
}
