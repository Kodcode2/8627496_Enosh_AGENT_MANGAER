using Microsoft.AspNetCore.Components.Routing;

namespace Agent_rest.Model
{
    public enum AgentStatus
    {
        Activ,
        InActiv
    }


    public class AgentModel
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public byte Image { get; set; }
        public int Location_X { get; set; }
        public int Location_Y { get; set; }
        public AgentStatus Status { get; set; }

        public ICollection<MissionModel>jdj kok 
    }
}
