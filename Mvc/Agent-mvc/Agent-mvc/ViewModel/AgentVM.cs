namespace Agent_mvc.ViewModel
{
    public enum AgentStatus
    {
        Active,
        InActive
    }


    public class AgentVM
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Image { get; set; }
        public int Location_X { get; set; } = -1;
        public int Location_Y { get; set; } = -1;
        public AgentStatus Status { get; set; } = AgentStatus.InActive;

    }
}
