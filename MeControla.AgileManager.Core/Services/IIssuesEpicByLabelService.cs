﻿using MeControla.AgileManager.Data.Dtos.Jira;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Services
{
    public interface IIssuesEpicByLabelService
    {
        Task<SearchDto> GetData(string project, string[] labels, CancellationToken cancellationToken);
    }
}