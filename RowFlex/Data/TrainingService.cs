using Microsoft.EntityFrameworkCore;
using RowFlex.Data;
using RowFlex.Models;

public class TrainingService
{
    private readonly ApplicationDbContext _dbContext;

    public TrainingService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    //Download all trainings
    public async Task<List<Training>> GetAllTrainingsAsync()
    {
        return await _dbContext.Trainings.ToListAsync();
    }

    // Add new training
    public async Task AddTrainingAsync(Training training)
    {
        _dbContext.Trainings.Add(training);
        await _dbContext.SaveChangesAsync();
    }
}
