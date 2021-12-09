using Confab.Shared.Abstractions.Exceptions;

namespace Confab.Modules.Conferences.Core.Exceptions
{
    internal class CannotDeleteHostException : ConfabException
    {
        public Guid Id { get; }
        
        public CannotDeleteHostException(Guid hostId) : base($"Host with ID: '{hostId}' cannot be deleted")
        {
            Id = hostId;
        }
    }
}