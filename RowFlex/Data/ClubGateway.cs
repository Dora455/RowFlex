using Microsoft.EntityFrameworkCore;
using RowFlex.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RowFlex.Data
{
    public class ClubGateway
    {
        private readonly ApplicationDbContext _context;

        public ClubGateway(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Club> AddAsync(Club club)
        {
            _context.Clubs.Add(club);
            await _context.SaveChangesAsync();
            return club;
        }

        public async Task<Club> GetByIdAsync(int id)
        {
            return await _context.Clubs
                .Include(c => c.Coaches)
                .Include(c => c.ClubMembers)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Club>> GetAllAsync()
        {
            return await _context.Clubs
                .Include(c => c.Coaches)
                .Include(c => c.ClubMembers)
                .ToListAsync();
        }

        public async Task<Club> UpdateAsync(Club club)
        {
            _context.Clubs.Update(club);
            await _context.SaveChangesAsync();
            return club;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var club = await _context.Clubs.FindAsync(id);
            if (club == null) return false;

            _context.Clubs.Remove(club);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
