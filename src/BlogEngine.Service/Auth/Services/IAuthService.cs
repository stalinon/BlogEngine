﻿using BlogEngine.Service.Auth.Models;

namespace BlogEngine.Service.Auth.Services;

/// <summary>
///     Авторизация
/// </summary>
public interface IAuthService
{
    /// <summary>
    ///     Зарегистрироваться
    /// </summary>
    public Task<bool> RegisterAsync(RegisterContract registerContract, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Залогиниться
    /// </summary>
    public Task<bool> LoginAsync(LoginContract loginContract, CancellationToken cancellationToken = default);
}
