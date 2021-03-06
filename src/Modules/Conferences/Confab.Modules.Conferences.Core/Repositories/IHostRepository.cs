using Confab.Modules.Conferences.Core.Entities;

namespace Confab.Modules.Conferences.Core.Repositories
{
    internal interface IHostRepository
    {
        Task CreateAsync(Host host);
        Task<Host> GetAsync(Guid id);
        Task<IReadOnlyList<Host>> BrowseAsync();
        Task UpdateAsync(Host host);
        Task DeleteAsync(Host host);
    }
}