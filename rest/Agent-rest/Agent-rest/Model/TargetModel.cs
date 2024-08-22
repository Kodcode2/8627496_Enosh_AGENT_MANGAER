namespace Agent_rest.Model
{
    public enum TargetStatus
    {
        alive,
        eliminated
    }

    public class TargetModel
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public string role { get; set; }
        public string Image { get; set; }
        public int Location_X { get; set; } = - 1; 
        public int Location_Y { get; set; } = - 1;
        public TargetStatus Status { get; set; } = TargetStatus.alive;
    }
}




// var res = targetservice switch
//{
//  _when targetservice.location.Contains("ne") => target.location += 1,
//  _when targetservice.location.Contains("w") => target.location += 1,
//}
