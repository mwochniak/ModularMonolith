using System;
using Confab.Shared.Abstractions.Exceptions;

namespace Confab.Modules.Conferences.Core.Exceptions
{
    internal class ConferenceNotFoundException : ConfabException
    {
        public Guid Id { get; }
        
        public ConferenceNotFoundException(Guid conferenceId) : base($"Conference with ID: '{conferenceId}' was not found")
        {
            Id = conferenceId;
        }
    }
}