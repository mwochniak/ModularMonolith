using Confab.Shared.Abstractions.Commands;
using Confab.Shared.Abstractions.Messaging;

namespace Confab.Modules.Agendas.Application.Submissions.Commands;

public record CreateSubmission(Guid ConferenceId, string Title, string Description, int Level,
    IEnumerable<string> Tags, IEnumerable<Guid> SpeakerIds) : ICommand
{
    public Guid Id { get; } = Guid.NewGuid();
    
    public Task PublishAsync(params IMessage[] messages)
    {
        throw new NotImplementedException();
    }
}