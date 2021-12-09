﻿using Confab.Modules.Users.Core.DTO;
using Confab.Shared.Abstractions.Auth;

namespace Confab.Modules.Users.Core.Services
{
    internal interface IIdentityService
    {
        Task<AccountDto> GetAsync(Guid id);
        Task SignUpAsync(SignUpDto dto);
        Task<JsonWebToken> SingInAsync(SignInDto dto);
    }
}