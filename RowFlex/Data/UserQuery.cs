using RowFlex.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RowFlex.Models;

public class UserQuery
{
    private readonly ApplicationDbContext _context;

    public UserQuery(ApplicationDbContext context)
    {
        _context = context;
    }

    public Task<User?> GetByEmailAsync(string email)
    {
        return _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public Task<List<User>> GetAllAsync()
    {
        return _context.Users.ToListAsync();
    }
    public User GetUserById(string userId)
    {
        return _context.Users.Find(userId);
    }
}
