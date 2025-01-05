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
}


