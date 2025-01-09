using RowFlex.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
namespace RowFlex.Models;

public class PresenceService
{
    private readonly ApplicationDbContext _context;

    public PresenceService(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<List<Presence>> GetAllUserErgometrPresence(string userId)
    {
        var result = await _context.Presences
                    .Where(p => p.UserId == userId)
                    .Include(p => p.TrainingPlan)
                    .ThenInclude(tp => tp.Training)
                    .Where(p => p.TrainingPlan != null && p.TrainingPlan.Training != null && p.TrainingPlan.Training.TrainingType ==
                    ETreningType.Ergometer)
                    .ToListAsync();
        return result;
    }
    public async Task<(bool Success, string Message)> AddPresenceAsync(string userId, int trainingPlanId)
    {
        try
        {
            var user = await _context.Users.FindAsync(userId);
            var trainingPlan = await _context.TrainingPlans.FindAsync(trainingPlanId);

            var existingPresence = await _context.Presences
                .FirstOrDefaultAsync(p => p.UserId == userId && p.TrainingPlanId == trainingPlanId);

            if (existingPresence != null)
            {
                return (false, "User is already marked as present for this training plan.");
            }

            var presence = new Presence
            {
                UserId = userId,
                TrainingPlanId = trainingPlanId,
                Date = DateTime.Now
            };

            _context.Presences.Add(presence);
            await _context.SaveChangesAsync();

            return (true, "Presence added successfully.");
        }
        catch (Exception ex)
        {
            return (false, $"An error occurred: {ex.Message}");
        }
    }

    public async Task<Presence> UpdatePresenceAsync(Presence presence)
    {
        _context.Presences.Update(presence);
        await _context.SaveChangesAsync();
        return presence;
    }

}

