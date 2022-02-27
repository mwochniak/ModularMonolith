using Confab.Shared.Abstractions.Commands;
using Confab.Shared.Abstractions.Messaging;

namespace Confab.Modules.Agendas.Application.Submissions.Commands;

public record ApproveSubmission(Guid Id) : ICommand
{
    public Task PublishAsync(params IMessage[] messages)
    {
        throw new NotImplementedException();
    }
}