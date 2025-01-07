using Microsoft.EntityFrameworkCore;
using RowFlex.Data;
using RowFlex.Models;

public class TrainingPlanService
{
    private readonly ApplicationDbContext _dbContext;

    public TrainingPlanService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<List<TrainingPlan>> GetAllTrainingPlansAsync()
    {
        return await _dbContext.TrainingPlans
            .Include(tp => tp.Training)
            .OrderByDescending(tp => tp.TrainingDate) // Sort by TrainingDate
            .ToListAsync();
    }

    // Add new training plan
    public async Task AddTrainingPlanAsync(TrainingPlan trainingPlan)
    {
        _dbContext.TrainingPlans.Add(trainingPlan);
        await _dbContext.SaveChangesAsync();
    }
    public async Task<TrainingPlan> GetClosestWaterTraining()
    {
        var closestWaterTraining = await _dbContext.TrainingPlans
        .Include(tp => tp.Training)
        .Where(tp => tp.Training != null && tp.Training.TrainingType == ETreningType.Water)
        .Where(tp => tp.TrainingDate >= DateTime.Now)
        .OrderBy(tp => tp.TrainingDate)
        .FirstOrDefaultAsync();

        return closestWaterTraining;
    }
    public async Task<List<Presence>> GetTrainingParticipants(TrainingPlan plan)
    {
        var presence = await _dbContext.Presences
                .Where(p => p.TrainingPlanId == plan.Id)
                .Include(p => p.User)
                .ToListAsync();
        return presence;
    }
}


