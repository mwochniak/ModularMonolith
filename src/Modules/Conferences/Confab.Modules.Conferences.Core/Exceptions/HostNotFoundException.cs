using System;
using Confab.Shared.Abstractions.Exceptions;

namespace Confab.Modules.Conferences.Core.Exceptions
{
    internal class HostNotFoundException : ConfabException
    {
        public Guid Id { get; }
        
        public HostNotFoundException(Guid hostId) : base($"Host with ID: '{hostId}' was not found")
        {
            Id = hostId;
        }
    }
}