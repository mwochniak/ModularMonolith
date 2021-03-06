using Confab.Modules.Agendas.Domain.Agendas.Entities;
using Confab.Shared.Abstractions.Kernel.Types;

namespace Confab.Modules.Agendas.Domain.Submissions.Entities;

public class Speaker : AggregateRoot
{
    public string FullName { get; init; }
    
    public IEnumerable<Submission> Submissions => _submissions;
    private readonly ICollection<Submission> _submissions;
    
    public IEnumerable<AgendaItem> AgendaItems => _agendaItems;
    private readonly ICollection<AgendaItem> _agendaItems;

    public Speaker(AggregateId id, string fullName, ICollection<Submission> submissions = null, ICollection<AgendaItem> agendaItems = null)
    {
        Id = id;
        FullName = fullName;
        _submissions = new List<Submission>(submissions ?? Enumerable.Empty<Submission>());
        _agendaItems = new List<AgendaItem>(agendaItems ?? Enumerable.Empty<AgendaItem>());
    }

    private Speaker()
    {
    }

    public static Speaker Create(Guid id, string fullName) => new(id, fullName);
}