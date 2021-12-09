using Confab.Modules.Conferences.Core.DTO;
using Confab.Modules.Conferences.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Confab.Modules.Conferences.Api.Controllers
{
    [Authorize(Policy = Policy)]
    internal class HostsController : BaseController
    {
        private readonly IHostService _hostService;
        private const string Policy = "hosts";

        public HostsController(IHostService hostService)
        {
            _hostService = hostService;
        }

        [AllowAnonymous]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<HostDetailsDto>> Get(Guid id)
            => OkOrNotFound(await _hostService.GetAsync(id));

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<HostDto>>> Get()
            => Ok(await _hostService.BrowseAsync());

        [HttpPost]
        public async Task<IActionResult> Post(HostDto dto)
        {
            await _hostService.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new {id = dto.Id}, null);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put(Guid id, HostDetailsDto dto)
        {
            dto.Id = id;
            await _hostService.UpdateAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _hostService.DeleteAsync(id);
            return NoContent();
        }
    }
}