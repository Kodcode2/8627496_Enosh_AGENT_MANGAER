using Agent_rest.Model;
using Agent_rest.Dto;
using System.Reflection.Metadata.Ecma335;
using Agent_rest.Data;
using System;
using Microsoft.IdentityModel.Tokens;

namespace Agent_rest.Utils
{


    public static class Utilities
    { 
        // פונקציית חישוב מרחק
        public static double CalculateRange(AgentModel agent, TargetModel target) =>
            Math.Sqrt(Math.Pow(agent.Location_X - target.Location_X, 2) + Math.Pow(agent.Location_Y - target.Location_Y, 2));



        // פונקציה לוודא שמיקום הסוכן או המטרה לא חורגים משטח המטריצה
        public static bool PinValid(AgentModel agentModel)
        {
            if (agentModel.Location_X > 0 && agentModel.Location_X < 1000
                && agentModel.Location_Y > 0 && agentModel.Location_Y < 1000)
            { return true; }
            return false;
        }


        // פונקציה שממירה את הסטרינג שמתקבל מהיוזר לנמבר
        public static Tuple<int, int> Move(MoveDto move)
        {
            Dictionary<string, (int x, int y)> directions = new()
            {
                {"ne", (+1, +1) },
                {"n", (0, +1) },
                {"nw", (+1, -1) },
                {"w", (-1, 0) },
                {"s", (0, -1) },
                {"se", (-1, +1) },
                {"sw", (-1, -1) },
                {"e", (+1, 0) }
            };
            var resolts = directions[move.direction];
            return new Tuple<int, int> (resolts.x, resolts.y);
        }



        // פונקצייה שבודקת את המיקום של הסוכן ביחס למטרה ומחזירה טרו אם הם בטווח לציוות
        public static bool LocationChecker(AgentModel agent, TargetModel target)
        {
            if (agent.Location_X == target.Location_X && agent.Location_Y == target.Location_Y)
            {
                target.Status = TargetStatus.eliminated;
                agent.Status = AgentStatus.InActive;
                return true;
            }
            return false;
        }
    }
}