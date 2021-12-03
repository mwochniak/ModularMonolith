using System.Collections.Generic;
using System.Linq;
using Confab.Modules.Speakers.Core.DTO;
using Confab.Modules.Speakers.Core.Entities;

namespace Confab.Modules.Speakers.Core.Mappings
{
    internal static class Extensions
    {
        public static IEnumerable<SpeakerDto> AsDtos(this IEnumerable<Speaker> speakers)
            => speakers.Select(AsDto);
        
        public static SpeakerDto AsDto(this Speaker speaker)
            => new()
            {
                Id = speaker.Id,
                FirstName = speaker.FirstName,
                LastName = speaker.LastName,
                Bio = speaker.Bio,
                AvatarUrl = speaker.AvatarUrl,
                Email = speaker.Email
            };
        
        internal static Speaker AsEntity(this SpeakerDto dto)
            => new()
            {
                Id = dto.Id,
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Bio = dto.Bio,
                AvatarUrl = dto.AvatarUrl
            };
    }
}