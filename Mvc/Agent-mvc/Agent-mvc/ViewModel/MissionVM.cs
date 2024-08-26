using Agent_mvc.Models;

namespace Agent_mvc.ViewModel
{
    public class MissionVM
    {
        public int Id { get; set; }
        public int TargetId { get; set; }
        public int AgentId { get; set; }
        public AgentVM Agent { get; set; }
        public TargetVM Target { get; set; }
        public MissionStatus Status { get; set; }
        public double TimeLeft { get; set; } = -1;
    }


    public enum MissionStatus
    {
        InAction,
        Proposal,
        Ended
    }
}
