using Confab.Modules.Conferences.Core.Entities;

namespace Confab.Modules.Conferences.Core.Repositories
{
    internal class InMemoryHostRepository : IHostRepository
    {
        // not thread-safe, use Concurrent collections
        private readonly List<Host> _hosts = new();

        public Task CreateAsync(Host host)
        {
            _hosts.Add(host);
            return Task.CompletedTask;
        }

        public async Task<Host> GetAsync(Guid id)
            => await Task.FromResult(_hosts.SingleOrDefault(x => x.Id == id));

        public async Task<IReadOnlyList<Host>> BrowseAsync()
            => await Task.FromResult(_hosts);

        public Task UpdateAsync(Host host)
        {
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Host host)
        {
            _hosts.Remove(host);
            return Task.CompletedTask;
        }
    }
}