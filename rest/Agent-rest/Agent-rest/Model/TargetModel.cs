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
        public byte Image { get; set; }
        public int Location_X { get; set; }
        public int Location_Y { get; set; }
        public TargetStatus Status { get; set; }
    }
}




// var res = targetservice switch
//{
//  _when targetservice.location.Contains("ne") => target.location += 1,
//  _when targetservice.location.Contains("w") => target.location += 1,
//}
