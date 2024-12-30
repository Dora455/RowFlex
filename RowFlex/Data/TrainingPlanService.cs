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

    // Download all training plans
    public async Task<List<TrainingPlan>> GetAllTrainingPlansAsync()
    {
        return await _dbContext.TrainingPlans.Include(tp => tp.Training).ToListAsync();
    }

    // Add new training plan
    public async Task AddTrainingPlanAsync(TrainingPlan trainingPlan)
    {
        _dbContext.TrainingPlans.Add(trainingPlan);
        await _dbContext.SaveChangesAsync();
    }
}
