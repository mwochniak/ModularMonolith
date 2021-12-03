using System;
using Confab.Shared.Abstractions.Exceptions;

namespace Confab.Modules.Conferences.Core.Exceptions
{
    internal class CannotDeleteConferenceException : ConfabException
    {
        public Guid Id { get; }
        
        public CannotDeleteConferenceException(Guid conferenceId) : base($"Conference with ID: '{conferenceId}' cannot be deleted")
        {
            Id = conferenceId;
        }
    }
}