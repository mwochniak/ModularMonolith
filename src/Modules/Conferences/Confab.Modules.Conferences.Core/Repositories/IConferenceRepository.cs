using Confab.Modules.Conferences.Core.Entities;

namespace Confab.Modules.Conferences.Core.Repositories
{
    internal interface IConferenceRepository
    {
        Task CreateAsync(Conference conference);
        Task<Conference> GetAsync(Guid id);
        Task<IReadOnlyList<Conference>> BrowseAsync();
        Task UpdateAsync(Conference conference);
        Task DeleteAsync(Conference conference);
    }
}