using Agent_rest.Data;
using Agent_rest.Dto;
using Agent_rest.Model;
using Microsoft.EntityFrameworkCore;
using static Agent_rest.Utils.Utilities;

namespace Agent_rest.Service
{
    public class TargetService(ApplicationDbContext context) : ITargetService
    {
        // פונקצייה שמביאה את כל המטרות
        public async Task<List<TargetModel>> GetAllTargetsAsync() =>
            await context.Targets.ToListAsync();


        // פונקצייה שמביאה מטרה ע"פ איי די 
        public async Task<TargetModel?> GetTargetByIdAsync(int id) =>
            await context.Targets.FirstOrDefaultAsync(target => target.Id == id);




        // פונקצייה שיוצרת מטרה
        public async Task<TargetModel> CreateTargetAsync(TargetDto targetDto)
        {
            if (targetDto == null)
            { throw new Exception("You cannot create an empty target"); }

            TargetModel target = new TargetModel()
            {
                Name = targetDto.Name,
                role = targetDto.Position,
                Image = targetDto.PhotoUrl
            };
            await context.Targets.AddAsync(target);
            await context.SaveChangesAsync();
            return target;
        }



        public async Task<TargetModel> TargetPinAsync(int id, PinDto pinDto)
        {
            if (pinDto == null)
            { throw new Exception("You cannot create an empty pin target"); }

            TargetModel? findById =  await GetTargetByIdAsync(id);
            findById.Location_X = pinDto.X;
            findById.Location_Y = pinDto.Y;

            var isValid = TargetPinValid(findById);
            if (!isValid) { throw new Exception("The new location is out of range"); }
            await context.SaveChangesAsync();
            return findById;
        }



        public async Task<TargetModel> MoveTargetAsync(int id, MoveDto moveDto)
        {
            var target = await GetTargetByIdAsync(id);

            var move = Move(moveDto);

            target.Location_X += move.Item1;
            target.Location_Y += move.Item2;

            var isValid = TargetPinValid(target);
            if (!isValid) { throw new Exception($"cannot be moved foreign target to the borders the matrix {target.Location_X}, {target.Location_Y}"); }

            await context.SaveChangesAsync();
            return target;
        }
    }
}
