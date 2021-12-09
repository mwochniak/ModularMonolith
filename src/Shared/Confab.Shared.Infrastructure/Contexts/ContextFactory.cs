using Confab.Shared.Abstractions.Contexts;
using Microsoft.AspNetCore.Http;

namespace Confab.Shared.Infrastructure.Contexts;

internal class ContextFactory : IContextFactory
{
    private readonly IHttpContextAccessor _accessor;

    public ContextFactory(IHttpContextAccessor accessor)
    {
        _accessor = accessor;
    }
    
    public IContext Create()
    {
        var httpContext = _accessor.HttpContext;

        return httpContext is null ? Context.Empty : new Context(httpContext);
    }
}