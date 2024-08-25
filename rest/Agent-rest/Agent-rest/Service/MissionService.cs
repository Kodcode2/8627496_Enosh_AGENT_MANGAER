using Agent_rest.Data;
using Agent_rest.Dto;
using Agent_rest.Model;
using Microsoft.EntityFrameworkCore;
using static Agent_rest.Utils.Utilities;

namespace Agent_rest.Service
{
    public class MissionService(ApplicationDbContext context) : IMissionService
    {
        // פונקצייה שמביאה את כל המשימות
        public async Task<List<MissionModel>> GetAllMissionsAsync() =>
            await context.Missions.ToListAsync();


        // פונקצייה שמביאה את המשימות ע"פ איי די
        public List<MissionModel> GetAllMissionsById(int id)
        {
            var agent = context.Agents.FirstOrDefault(ag => ag.Id == id);
            var missions = agent.OptionalTargets;
            return missions;
        }



        // פונקציה שבודקת טווח בין סוכן למטרה ואם זה בטווח הנכון היא מוסיפה הצעה לליסט
        public async Task<List<MissionModel>> MissionProposal()
        {
            var agents = await context.Agents.ToListAsync();
            var targets = await context.Targets.ToListAsync();

            var rangeCheck = await RangeCheck(agents, targets);
            return rangeCheck;
        }



        // פונקצייה שמעדכנת את הסטטוס של המשימה ושל הסוכן
        public async Task<MissionModel> UpdateMissionStatusAsync(int missionId)
        {
            var mission = await context.Missions.FirstOrDefaultAsync(miss => miss.Id == missionId);
            mission.Status = MissionStatus.InAction;
            var agent = await context.Agents.FirstOrDefaultAsync(ag => ag.Id == mission.AgentId);
            agent.Status = AgentStatus.Active;
            var timeLeft = TimeLeft(mission);
            context.SaveChanges();
            
            return mission;
        }



        // פונקצייה שמעדכנת את המיקום של הסוכן ובודקת אם המשימה הושלמה
        // אם המשימה הושלמה היא משנה את הסטטוסים
        public async Task<MissionModel> UpdateLocations(int missionId)
        {
            var mission = await context.Missions.FirstOrDefaultAsync(miss => miss.Id == missionId);
            var agent = await context.Agents.FirstOrDefaultAsync(ag => ag.Id == mission.AgentId);
            var target = await context.Targets.FirstOrDefaultAsync(tar => tar.Id == mission.TargetId);

            var checkStatus = LocationChecker(agent, target);
            if (checkStatus)
            {
                mission.Status = MissionStatus.Ended;
                mission.TimeLeft = -1;
                agent.Status = AgentStatus.InActive;
                target.Status = TargetStatus.eliminated;
                context.SaveChanges();
            }

            if (mission.Status == MissionStatus.InAction)
            {
                var direction = DirectionCalculation(agent, target);
                context.SaveChanges();
            }
            return mission;
        }








        // utils
        public async Task<List<MissionModel>> RangeCheck(List<AgentModel> agents, List<TargetModel> targets)
        {
            foreach (var target in targets)
            {
                foreach (var agent in agents)
                {
                    var calculat = CalculateRange(agent, target);
                    if (calculat < 200)
                    {
                        MissionModel mission = new()
                        {
                            TargetId = target.Id,
                            AgentId = agent.Id,
                            Target = target,
                            Agent = agent,
                            Status = MissionStatus.Proposal,
                        };
                        context.Missions.Add(mission);
                        context.SaveChanges();
                    }
                }
            }
            return new List<MissionModel>();
        }


        public MissionModel TimeLeft(MissionModel mission)
        {
            var agent = context.Agents.FirstOrDefault(ag => ag.Id == mission.AgentId);
            var target = context.Targets.FirstOrDefault(tar => tar.Id == mission.TargetId);
           
            var timeLeft = CalculateRange(agent, target) / 5;
            mission.TimeLeft = timeLeft;
            return mission;
        }


        public AgentModel DirectionCalculation(AgentModel agent, TargetModel target)
        {
            int agentX = agent.Location_X.CompareTo(target.Location_X) switch
            {
                -1 => agent.Location_X + 1,
                1 => agent.Location_Y - 1,
                _ => 0
            };
            int agentY = agent.Location_Y.CompareTo(target.Location_Y) switch
            {
                -1 => agent.Location_Y + 1,
                1 => agent.Location_Y - 1,
                _ => 0
            };
            agent.Location_X = agentX;
            agent.Location_Y = agentY;
            context.SaveChanges();
            return agent;
        }
    }
}































//foreach (var target in targets)
//{
//    foreach (var agent in agents)
//    {
//        var calculat = CalculateRange(agent, target);
//        if (calculat < 200)
//        {
//            MissionModel mission = new()
//            {
//                TargetId = target.Id,
//                AgentId = agent.Id,
//                Target = target,
//                Agent = agent,
//                Status = MissionStatus.Proposal,
//            };
//            context.Missions.Add(mission);
//            context.SaveChanges();
//        }
//    }
//}
//return new MissionModel();
