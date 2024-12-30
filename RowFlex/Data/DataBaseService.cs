using RowFlex.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RowFlex.Models;

public class DataBaseService
{
    private ApplicationDbContext _context;

    public DataBaseService(ApplicationDbContext context)
    {
        _context = context;
    }

    public Task<List<Event>> GetAllEventsAsync()
    {
        return _context.Events.ToListAsync();
    }

    public async Task RemoveEventAsync(int eventId)
    {

        var _event = await _context.Events.FindAsync(eventId);
        if (_event != null)
        {
            _context.Events.Remove(_event);
            await _context.SaveChangesAsync();
        }
    }

    public async Task AddEventAsync(Event _event)
    {
        _context.Events.Add(_event);
        await _context.SaveChangesAsync();
    }
    public Task<List<News>> GetAllNewsAsync()
    {
        return _context.News.ToListAsync();
    }
    public async Task AddNewsAsync(News news)
    {
        _context.News.Add(news);
        await _context.SaveChangesAsync();
    }
}