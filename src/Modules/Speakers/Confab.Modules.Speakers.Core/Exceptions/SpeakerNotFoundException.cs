using System;
using Confab.Shared.Abstractions.Exceptions;

namespace Confab.Modules.Speakers.Core.Exceptions
{
    internal class SpeakerNotFoundException : ConfabException
    {
        public Guid Id { get; }
        
        public SpeakerNotFoundException(Guid speakerId) : base($"Speaker with ID: '{speakerId}' was not found")
        {
            Id = speakerId;
        }
    }
}