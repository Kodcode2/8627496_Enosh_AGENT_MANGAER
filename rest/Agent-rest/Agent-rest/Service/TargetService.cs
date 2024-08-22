using Agent_rest.Data;
using Agent_rest.Dto;
using Agent_rest.Model;
using Microsoft.EntityFrameworkCore;

namespace Agent_rest.Service
{
    public class TargetService(ApplicationDbContext context) : ITargetService
    {
        public async Task<TargetModel> GetTargetsAsync(TargetGetDto getDto)
        {
            return new TargetModel();
        }


        public async Task<TargetModel?> GetTargetByIdAsync(int id) =>
            await context.Targets.FirstOrDefaultAsync(target => target.Id == id);


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
    }
}
