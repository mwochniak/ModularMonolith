﻿using Confab.Modules.Speakers.Core.DTO;
using Confab.Modules.Speakers.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Confab.Modules.Speakers.Api.Controllers
{
    [Authorize(Policy = Policy)]
    internal class SpeakersController : BaseController
    {
        private const string Policy = "speakers";
        private readonly ISpeakerService _speakerService;

        public SpeakersController(ISpeakerService speakerService)
        {
            _speakerService = speakerService;
        }
        
        [AllowAnonymous]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<SpeakerDto>> Get(Guid id)
            => OkOrNotFound(await _speakerService.GetAsync(id));

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<SpeakerDto>>> Get()
            => Ok(await _speakerService.BrowseAsync());

        [HttpPost]
        public async Task<IActionResult> Post(SpeakerDto dto)
        {
            await _speakerService.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new {id = dto.Id}, null);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put(Guid id, SpeakerDto dto)
        {
            dto.Id = id;
            await _speakerService.UpdateAsync(dto);
            return NoContent();
        }
        
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _speakerService.DeleteAsync(id);
            return NoContent();
        }
    }
}