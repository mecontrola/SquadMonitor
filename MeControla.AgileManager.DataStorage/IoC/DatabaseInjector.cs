﻿using MeControla.AgileManager.DataStorage.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

namespace MeControla.AgileManager.DataStorage.IoC
{
    public static class DatabaseInjector
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.TryAddTransient<ICustomfieldRepository, CustomfieldRepository>();
            services.TryAddTransient<IIssueCustomfieldDataRepository, IssueCustomfieldDataRepository>();
            services.TryAddTransient<IIssueEpicRepository, IssueEpicRepository>();
            services.TryAddTransient<IIssueRepository, IssueRepository>();
            services.TryAddTransient<IIssueImpedimentRepository, IssueImpedimentRepository>();
            services.TryAddTransient<IIssueTypeRepository, IssueTypeRepository>();
            services.TryAddTransient<IIssueStatusHistoryRepository, IssueStatusHistoryRepository>();
            services.TryAddTransient<IProjectRepository, ProjectRepository>();
            services.TryAddTransient<IProjectCategoryRepository, ProjectCategoryRepository>();
            services.TryAddTransient<IQuarterRepository, QuarterRepository>();
            services.TryAddTransient<IStatusRepository, StatusRepository>();
            services.TryAddTransient<IStatusCategoryRepository, StatusCategoryRepository>();
        }
    }
}