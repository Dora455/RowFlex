using RowFlex.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RowFlex.Models;

public class IndividualTrainingService
{
    private ApplicationDbContext _context;

    public IndividualTrainingService(ApplicationDbContext context)
    {
        _context = context;
    }

    // Create
    public async Task AddAsync(IndividualTraining training)
    {
        _context.IndividualTrainings.Add(training);
        await _context.SaveChangesAsync();
    }

    // Read
    public async Task<IndividualTraining> GetByIdAsync(int id)
    {
        return await _context.IndividualTrainings
                             .Include(t => t.Training)
                             .Include(t => t.User)
                             .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<List<IndividualTraining>> GetAllAsync()
    {
        return await _context.IndividualTrainings
                             .Include(t => t.Training)
                             .Include(t => t.User)
                             .ToListAsync();
    }

    public async Task<List<IndividualTraining>> GetByUserIdAsync(string userId)
    {
        return await _context.IndividualTrainings
                             .Where(t => t.UserId == userId)
                             .Include(t => t.Training)
                             .Include(t => t.User)
                             .ToListAsync();
    }

    public async Task UpdateAsync(IndividualTraining updatedTraining)
    {
        _context.IndividualTrainings.Update(updatedTraining);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var training = await _context.IndividualTrainings.FindAsync(id);
        _context.IndividualTrainings.Remove(training);
        await _context.SaveChangesAsync();
    }

    public async Task<List<IndividualTraining>> GetAllUserErgometrIndividualTrainings(string userId)
    {
        var res = await _context.IndividualTrainings
                .Where(it => it.UserId == userId)
                .Include(it => it.Training)
                .Where(it => it.Training != null && it.Training.TrainingType == ETreningType.Ergometer)
                .ToListAsync();
        return res;
    }
    public async Task<List<IndividualTraining>> GetAllUserIndividualTrainings(string userId)
    {
        var res = await _context.IndividualTrainings
                    .Where(it => it.UserId == userId)
                    .Include(it => it.Training)
                    .OrderByDescending(it => it.TrainingDate)
                    .ToListAsync();
        return res;
    }

}
