using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Confab.Modules.Speakers.Core.DTO;

namespace Confab.Modules.Speakers.Core.Services
{
    public interface ISpeakerService
    {
        Task CreateAsync(SpeakerDto dto);
        Task<SpeakerDto> GetAsync(Guid id);
        Task<IReadOnlyList<SpeakerDto>> BrowseAsync();
        Task UpdateAsync(SpeakerDto dto);
        Task DeleteAsync(Guid id);
    }
}