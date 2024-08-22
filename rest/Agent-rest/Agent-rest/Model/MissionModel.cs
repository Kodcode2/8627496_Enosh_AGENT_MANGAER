namespace Agent_rest.Model
{
    public enum MissionStatus
    {
        InAction,
        Proposal,
        Ended
    }
    public class MissionModel
    {
        public int Id { get; set; }
        public int TargetId { get; set; }
        public int AgentId { get; set; }
        public AgentModel Agent { get; set; }
        public TargetModel Target { get; set; }
        public MissionStatus Status { get; set; }
        public double TimeLeft { get; set; }
    }
}
