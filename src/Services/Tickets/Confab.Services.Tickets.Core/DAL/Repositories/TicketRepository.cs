﻿using Confab.Services.Tickets.Core.Entities;
using Confab.Services.Tickets.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Confab.Services.Tickets.Core.DAL.Repositories;

internal class TicketRepository : ITicketRepository
{
    private readonly TicketsDbContext _context;
    private readonly DbSet<Ticket> _tickets;

    public TicketRepository(TicketsDbContext context)
    {
        _context = context;
        _tickets = _context.Tickets;
    }

    public Task<Ticket> GetAsync(Guid conferenceId, Guid userId)
        => _tickets.SingleOrDefaultAsync(x => x.ConferenceId == conferenceId && x.UserId == userId);

    public Task<int> CountForConferenceAsync(Guid conferenceId)
        => _tickets.CountAsync(x => x.ConferenceId == conferenceId);

    public async Task<IReadOnlyList<Ticket>> GetForUserAsync(Guid userId)
        => await _tickets.Include(x => x.Conference).Where(x => x.UserId == userId).ToListAsync();

    public Task<Ticket> GetAsync(string code)
        => _tickets.SingleOrDefaultAsync(x => x.Code == code);

    public async Task AddAsync(Ticket ticket)
    {
        await _tickets.AddAsync(ticket);
        await _context.SaveChangesAsync();
    }

    public async Task AddManyAsync(IEnumerable<Ticket> ticket)
    {
        await _tickets.AddRangeAsync(ticket);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Ticket ticket)
    {
        _tickets.Update(ticket);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Ticket ticket)
    {
        _tickets.Remove(ticket);
        await _context.SaveChangesAsync();
    }
}