using Agent_rest.Data;
using Agent_rest.Model;

namespace Agent_rest.Service
{
    public class CalculationsService(ApplicationDbContext context) : ICalculationsService
    {
        public async Task<(int sum, int act)> SumAgents()
        {
            int count = 0;
            int active = 0;
            foreach (var agent in context.Agents.ToList())
            {
                count++;
                if (agent.Status == AgentStatus.Active)
                {
                    active++;
                }
            }
            return (count, active);
        }



        public async Task<(int sum, int kill)> SumTargets()
        {
            int count = 0;
            int end = 0;
            foreach (var target in context.Targets.ToList())
            {
                count++;
                if (target.Status == TargetStatus.eliminated)
                {
                    end++;
                }
            }
            return (count, end);
        }


        public async Task<(int sum, int act, int pro)> SumMissions()
        {
            int count = 0;
            int action = 0;
            int proposal = 0;
            foreach (var mission in context.Missions.ToList())
            {
                count++;
                if (mission.Status == MissionStatus.InAction)
                {
                    action++;
                }
                if (mission.Status == MissionStatus.Proposal)
                {
                    proposal++;
                }
            }
            return (count, action, proposal);
        }



        public double GetRatio(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                return 0;
            }
            return (double)numerator / denominator;
        }
    }
}


    

