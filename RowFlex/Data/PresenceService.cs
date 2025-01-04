using RowFlex.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;  // Dodaj tę przestrzeń nazw
using System.Security.Claims;
namespace RowFlex.Models;

public class PresenceService
{
    private readonly ApplicationDbContext _context;

    public PresenceService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<(bool Success, string Message)> AddPresenceAsync(string userId, int trainingPlanId)
{
    try
    {
        // Find user by userId
        var user = await _context.Users.FindAsync(userId);

        if (user == null)
        {
            return (false, $"No user found with ID: {userId}");
        }

        // Find training plan by trainingPlanId
        var trainingPlan = await _context.TrainingPlans.FindAsync(trainingPlanId);

        if (trainingPlan == null)
        {
            return (false, $"No training plan found with ID: {trainingPlanId}");
        }

        // Check if the user is already present for this training plan
        var existingPresence = await _context.Presences
            .FirstOrDefaultAsync(p => p.UserId == userId && p.TrainingPlanId == trainingPlanId);

        if (existingPresence != null)
        {
            return (false, "User is already marked as present for this training plan.");
        }

        // Add new presence
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
        // Log or handle exception
        return (false, $"An error occurred: {ex.Message}");
    }
}

}
