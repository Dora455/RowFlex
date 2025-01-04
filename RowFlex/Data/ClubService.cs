using RowFlex.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RowFlex.Models;

public class ClubService
{
    private ApplicationDbContext _context;

    public ClubService(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<Club> GetClubsForCoach(string coachId)
    {
        return _context.Clubs
            .Where(c => c.Coaches.Any(coach => coach.CoachId == coachId))
            .ToList();
    }
    public Club GetClubById(int clubId)
    {
        return _context.Clubs
            .Include(c => c.Coaches)
            .Include(c => c.ClubMembers)
            .FirstOrDefault(c => c.Id == clubId);
    }
    public User GetUserById(string userId)
    {
        return _context.Users.Find(userId);
    }
    public async Task<User?> GetUserByEmail(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }
    public async Task<List<ClubMembership>> GetAllAthletesForClub(int clubId)
    {
        return _context.ClubMemberships
            .Where(cm => cm.ClubId == clubId)
            .Include(cm => cm.Athlete)
            .ToList();
    }

    public async Task<List<Club>> GetAllClubsAsync()
    {
        return await _context.Clubs.ToListAsync();
    }
    public async Task AddNewClub(Club club)
    {
        _context.Clubs.Add(club);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveClubAsync(int clubId)
    {
        var clubCoaches = _context.ClubCoaches.Where(cc => cc.ClubId == clubId);
        _context.ClubCoaches.RemoveRange(clubCoaches);

        var clubMemberships = _context.ClubMemberships.Where(cm => cm.ClubId == clubId);
        _context.ClubMemberships.RemoveRange(clubMemberships);

        // Step 3: Delete the club itself
        var club = await _context.Clubs.FindAsync(clubId);
        _context.Clubs.Remove(club);
        await _context.SaveChangesAsync();
    }
    public async Task<List<ClubCoach>> GetAllClubCoachesAsync()
    {
        return await _context.ClubCoaches
        .Include(cc => cc.Club)
        .Include(cc => cc.Coach)
        .ToListAsync();
    }
    public async Task<List<User>> GetAllCoachesAsync()
    {
        return await _context.Users.Where(u => u.Role == "Coach").ToListAsync();
    }
    public async Task AddAthleteMembership(ClubMembership membership)
    {
        _context.ClubMemberships.Add(membership);
        await _context.SaveChangesAsync();
    }

    public async Task AddCoachToClubAsync(ClubCoach clubCoach)
    {
        _context.ClubCoaches.Add(clubCoach);
        await _context.SaveChangesAsync();
    }
    public async Task UpdateUserClub(User user, int clubId)
    {
        user.ClubId = clubId; // Assign coach to the club
        await _context.SaveChangesAsync();
    }
    public async Task UpdateAthlete(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateCoachClub(User user, ClubCoach clubCoach)
    {
        var tmp = user.ClubsAsCoach;
        tmp.Add(clubCoach);
        user.ClubsAsCoach = tmp; // Assign coach to the club
        await _context.SaveChangesAsync();
    }

    public async Task AcceptAthlete(int membershipId)
    {
        var membership = await _context.ClubMemberships.FindAsync(membershipId);
        if (membership != null)
        {
            membership.Status = MembershipStatus.Accepted;
            membership.Athlete.ClubId = membership.ClubId;
            await _context.SaveChangesAsync();
        }
    }

    public async Task RejectAthlete(int membershipId)
    {
        var membership = await _context.ClubMemberships.FindAsync(membershipId);
        if (membership != null)
        {
            membership.Status = MembershipStatus.Rejected;
            await _context.SaveChangesAsync();
        }
    }
    public List<ClubCoach> GetCoachesForClub(int clubId)
    {
        return _context.ClubCoaches
            .Where(u => u.ClubId == clubId)
            .ToList();
    }

    public ClubCoach GetCoacheClub(string userId, int clubId)
    {
        return _context.ClubCoaches
            .FirstOrDefault(u => u.ClubId == clubId && u.CoachId == userId);
    }
    public async Task RemoveCoachFromClubAsync(int clubCoachId)
    {
        var clubCoach = await _context.ClubCoaches.FindAsync(clubCoachId);
        if (clubCoach != null)
        {
            _context.ClubCoaches.Remove(clubCoach);
            await _context.SaveChangesAsync();
        }
    }
    public async Task<List<ClubMembership>> GetUserMembershipsAsync(string userId)
    {
        return await _context.ClubMemberships
            .Where(m => m.AthleteId == userId)
            .Include(m => m.Club)
            .ToListAsync();
    }
    public async Task RemoveMembershipAsync(int membershipId)
    {
        var membership = await _context.ClubMemberships.FindAsync(membershipId);
        if (membership != null)
        {
            _context.ClubMemberships.Remove(membership);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<WeightMeasurement> GetLatestWeightMeasurement(string athleteId)
    {
        return await _context.WeightMeasurements
            .Where(w => w.AthleteId == athleteId)
            .OrderByDescending(w => w.Date)
            .FirstOrDefaultAsync();
    }

    public string GetWeightCategory(User user, double weight)
    {
        if (user.Gender == EGender.Female)
        {
            if (weight <= 57.5)
                return "Light Weight";
            else
                return "Open Weight";
        }
        else if (user.Gender == EGender.Male)
        {
            if (weight <= 72.5)
                return "Light Weight";
            else
                return "Open Weight";
        }
        else
            return "Not gender specified";
    }
}