using Confab.Modules.Speakers.Core.Entities;

namespace Confab.Modules.Speakers.Core.Repositories
{
    public interface ISpeakerRepository
    {
        Task<bool> ExistsAsync(string email);
        Task<bool> ExistsAsync(Guid id);
        Task AddAsync(Speaker speaker);
        Task<Speaker> GetAsync(Guid id);
        Task<IReadOnlyList<Speaker>> BrowseAsync();
        Task UpdateAsync(Speaker speaker);
        Task DeleteAsync(Speaker speaker);
    }
}