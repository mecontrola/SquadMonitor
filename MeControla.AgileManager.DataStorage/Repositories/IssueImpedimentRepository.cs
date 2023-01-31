﻿using MeControla.AgileManager.Data.Entities;
using MeControla.AgileManager.Data.Enums;
using MeControla.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.DataStorage.Repositories
{
    public class IssueImpedimentRepository : BaseAsyncRepository<IssueImpediment>, IIssueImpedimentRepository
    {
        public IssueImpedimentRepository(IDbAppContext context)
            : base(context, context.IssueImpediments)
        { }

        public async Task<IssueImpediment> RetrieveByIssueAndStartAsync(long issueId, DateTime impedimentStart, CancellationToken cancellationToken)
            => await FindAsync(entity => entity.IssueId == issueId
                                      && entity.Start == impedimentStart, cancellationToken);

        public async Task<IList<IssueImpediment>> RetrieveByDateRangeAsync(long projectId, DateTime initDate, DateTime endDate, CancellationToken cancellationToken)
            => await dbSet.AsNoTracking()
                          .Include(entity => entity.Issue)
                          .ThenInclude(entity => entity.IssueType)
                          .Include(entity => entity.Issue)
                          .ThenInclude(entity => entity.Status)
                          .Where(entity => entity.Issue.ProjectId == projectId
                                        && entity.Issue.Status.Key != (long)StatusTypes.Removed
                                        && entity.Issue.Status.Key != (long)StatusTypes.Cancelled
                                        && entity.Start.Date <= endDate.Date
                                        && (entity.End == null || (entity.End.Value.Date >= initDate.Date && entity.End.Value.Date <= endDate.Date)))
                          .ToListAsync(cancellationToken);
    }
}