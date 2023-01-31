﻿using MeControla.AgileManager.Data.Parameters;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Services.Synchronizers.ExtraIssueData
{
    public interface IIssueCustomfieldDataSynchronizerService
    {
        Task Save(IssueSynchronizerParam parameters, CancellationToken cancellationToken);
    }
}