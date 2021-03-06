using Confab.Modules.Speakers.Core.Entities;
using Confab.Modules.Speakers.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Confab.Modules.Speakers.Core.DAL.Repositories
{
    internal class SpeakerRepository : ISpeakerRepository
    {
        private readonly SpeakersDbContext _dbContext;
        private readonly DbSet<Speaker> _speakers;

        public SpeakerRepository(SpeakersDbContext dbContext)
        {
            _dbContext = dbContext;
            _speakers = dbContext.Speakers;
        }

        public async Task<bool> ExistsAsync(string email)
            => await _dbContext.Speakers.AnyAsync(x => x.Email == email); 
        
        public async Task<bool> ExistsAsync(Guid id)
            => await _dbContext.Speakers.AnyAsync(x => x.Id == id);
        
        public async Task AddAsync(Speaker speaker)
        {
            await _speakers.AddAsync(speaker);
            await _dbContext.SaveChangesAsync();
        }

        public Task<Speaker> GetAsync(Guid id)
            => _speakers.SingleOrDefaultAsync(x => x.Id == id);

        public async Task<IReadOnlyList<Speaker>> BrowseAsync()
            => await _speakers.ToListAsync();

        public async Task UpdateAsync(Speaker speaker)
        {
            _speakers.Update(speaker);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Speaker speaker)
        {
            _speakers.Remove(speaker);
            await _dbContext.SaveChangesAsync();
        }
    }
}