using Confab.Shared.Abstractions.Commands;

namespace Confab.Modules.Agendas.Application.Agendas.Commands;

public sealed record CreateAgendaTrack(Guid ConferenceId, string Name) : ICommand
{
    public Guid Id { get; } = Guid.NewGuid();
}