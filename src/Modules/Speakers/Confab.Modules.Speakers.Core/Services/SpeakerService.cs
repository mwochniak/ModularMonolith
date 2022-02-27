using Confab.Modules.Speakers.Core.DTO;
using Confab.Modules.Speakers.Core.Events;
using Confab.Modules.Speakers.Core.Exceptions;
using Confab.Modules.Speakers.Core.Repositories;
using Confab.Modules.Speakers.Core.Mappings;
using Confab.Shared.Abstractions.Messaging;

namespace Confab.Modules.Speakers.Core.Services
{
    public class SpeakerService : ISpeakerService
    {
        private readonly ISpeakerRepository _speakerRepository;
        private readonly IMessageBroker _messageBroker;
        
        public SpeakerService(ISpeakerRepository speakerRepository, IMessageBroker messageBroker)
        {
            _speakerRepository = speakerRepository;
            _messageBroker = messageBroker;
        }

        public async Task CreateAsync(SpeakerDto dto)
        {
            var alreadyExists = await _speakerRepository.ExistsAsync(dto.Email);

            if (alreadyExists)
                throw new SpeakerAlreadyExistsException(dto.Email);

            dto.Id = Guid.NewGuid();
            await _speakerRepository.AddAsync(dto.AsEntity());
            await _messageBroker.PublishAsync(new SpeakerCreated(dto.Id, $"{dto.FirstName} {dto.LastName}"));
        }

        public async Task<SpeakerDto> GetAsync(Guid id)
            => (await _speakerRepository.GetAsync(id)).AsDto();

        public async Task<IReadOnlyList<SpeakerDto>> BrowseAsync()
            => (await _speakerRepository.BrowseAsync()).AsDtos().ToList();

        public async Task UpdateAsync(SpeakerDto dto)
        {
            var speakerExists = await _speakerRepository.ExistsAsync(dto.Id);

            if (!speakerExists)
                throw new SpeakerNotFoundException(dto.Id);

            await _speakerRepository.UpdateAsync(dto.AsEntity());
        }

        public async Task DeleteAsync(Guid id)
        {
            var speaker = await _speakerRepository.GetAsync(id);

            if (speaker is null)
                throw new SpeakerNotFoundException(id);

            await _speakerRepository.DeleteAsync(speaker);
        }
    }
}