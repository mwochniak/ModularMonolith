using Confab.Modules.Agendas.Domain.Submissions.Entities;
using Confab.Modules.Agendas.Domain.Submissions.Repositories;
using Confab.Shared.Abstractions.Kernel.Types;
using Microsoft.EntityFrameworkCore;

namespace Confab.Modules.Agendas.Infrastructure.EF.Repositories;

internal class SpeakerRepository : ISpeakerRepository
{
    private readonly AgendasDbContext _agendasDbContext;
    private readonly DbSet<Speaker> _speakers;

    public SpeakerRepository(AgendasDbContext agendasDbContext)
    {
        _agendasDbContext = agendasDbContext;
        _speakers = agendasDbContext.Speakers;
    }

    public async Task<bool> ExistsAsync(AggregateId id)
        => await _speakers.AnyAsync(x => x.Id.Equals(id));

    public async Task<IEnumerable<Speaker>> BrowseAsync(IEnumerable<AggregateId> ids)
        => await _speakers.Where(x => ids.Contains(x.Id)).ToListAsync();

    public async Task CreateAsync(Speaker speaker)
    {
        await _speakers.AddAsync(speaker);
        await _agendasDbContext.SaveChangesAsync();
    }
}