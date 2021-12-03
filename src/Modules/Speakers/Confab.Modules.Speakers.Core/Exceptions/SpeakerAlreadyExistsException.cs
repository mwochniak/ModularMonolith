using Confab.Shared.Abstractions.Exceptions;

namespace Confab.Modules.Speakers.Core.Exceptions
{
    internal class SpeakerAlreadyExistsException : ConfabException
    {
        public string SpeakerEmail { get; }
        
        public SpeakerAlreadyExistsException(string speakerEmail) : base($"Speaker with email: '{speakerEmail}' already exists")
        {
            SpeakerEmail = speakerEmail;
        }
    }
}