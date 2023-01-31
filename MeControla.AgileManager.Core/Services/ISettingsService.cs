﻿using MeControla.AgileManager.Data.Dtos.Settings;
using MeControla.AgileManager.Integrations.Jira.Data.Configurations;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Services
{
    public interface ISettingsService
    {
        Task<AppSettingsDto> LoadDataAsync(CancellationToken cancellationToken);
        Task<bool> SavePreferencesAsync(bool persistFilter, bool syncAllData, int cache, CancellationToken cancellationToken);
        Task<bool> SaveAuthenticationAsync(string url, string username, string password, CancellationToken cancellationToken);
        Task<bool> SaveFilterDataAsync(AppFilterDto filterData, CancellationToken cancellationToken);
        Task<bool> IsAuthenticationDataValidAsync(CancellationToken cancellationToken);
        JiraConfiguration GetJiraConfiguration();
        void RunCheckJiraConfigurationChanged(Action<JiraConfiguration> action);
    }
}