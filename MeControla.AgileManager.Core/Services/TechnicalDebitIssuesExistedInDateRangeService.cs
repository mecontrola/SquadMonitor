﻿using MeControla.AgileManager.Core.Extensions;
using MeControla.AgileManager.Data.Enums;
using MeControla.AgileManager.Integrations.Jira.Builders;
using MeControla.AgileManager.Integrations.Jira.Rest.V3.Issues;
using System;

namespace MeControla.AgileManager.Core.Services
{
    public class TechnicalDebitIssuesExistedInDateRangeService : BaseIssuesInDateRangesService, ITechnicalDebitIssuesExistedInDateRangeService
    {
        public TechnicalDebitIssuesExistedInDateRangeService(ISearchPost searchPost)
            : base(searchPost)
        { }

        protected override JqlBuilder CreateJql(string project, DateTime initDate, DateTime endDate)
            => JqlBuilder.GetInstance()
                         .AddProjectCriteria(project)
                         .AddInIssueTypesCriteria(IssueTypes.TechnicalDebt)
                         .AddCreatedIsLessThan(initDate)
                         .AddOr(x => x.AddAnd(y => y.AddResolvedIsNull()
                                                    .AddNotInDeletedStatusesCriteria())
                                      .AddBetweenResolvedDateCriteria(initDate, endDate));
    }
}