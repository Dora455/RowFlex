using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RowFlex.Models;

namespace RowFlex.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<User>(options)
{
    public DbSet<Training> Trainings { get; set; }
    public DbSet<TrainingPlan> TrainingPlans { get; set; }
    public DbSet<IndividualTraining> IndividualTrainings { get; set; }
    public DbSet<Presence> Presences { get; set; }
    public DbSet<Club> Clubs { get; set; }
    public DbSet<ClubMembership> ClubMemberships { get; set; }
    public DbSet<ClubCoach> ClubCoaches { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<News> News { get; set; }
    public DbSet<WeightMeasurement> WeightMeasurements { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
    }
}
