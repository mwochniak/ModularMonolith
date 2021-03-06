using Confab.Modules.Conferences.Core.Entities;

namespace Confab.Modules.Conferences.Core.Repositories
{
    internal class InMemoryConferenceRepository : IConferenceRepository
    {
        // not thread-safe, use Concurrent collections
        private readonly List<Conference> _conferences = new();

        public Task CreateAsync(Conference conference)
        {
            _conferences.Add(conference);
            return Task.CompletedTask;
        }

        public async Task<Conference> GetAsync(Guid id)
            => await Task.FromResult(_conferences.SingleOrDefault(x => x.Id == id));

        public async Task<IReadOnlyList<Conference>> BrowseAsync()
            => await Task.FromResult(_conferences);

        public Task UpdateAsync(Conference conference)
        {
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Conference conference)
        {
            _conferences.Remove(conference);
            return Task.CompletedTask;
        }
    }
}