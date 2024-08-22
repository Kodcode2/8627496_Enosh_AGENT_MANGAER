using Agent_rest.Model;
using Agent_rest.Dto;

namespace Agent_rest.Utils
{
    

    public static class Utilities
    {


        public static double CalculateRange(AgentPinDto agentPin, TargetPinDto targetPin) =>
            Math.Sqrt(Math.Pow(agentPin.x - targetPin.x, 2) + Math.Pow(agentPin.y - targetPin.y, 2));



        public static bool PinValid(AgentPinDto pinDto)
        {
            if (pinDto.x > 0 && pinDto.x < 1000 
                && pinDto.y > 0 && pinDto.y < 1000) 
                { return true; }
            return false;
        }


        
    }
}
