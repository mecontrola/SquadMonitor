﻿using MeControla.AgileManager.Integrations.Jira.Builders;
using MeControla.AgileManager.Integrations.Jira.Rest.V3.Issues;
using System;

namespace MeControla.AgileManager.Core.Services
{
    public class BugIncidentIssuesCreateInDateRangeService : BaseIssuesInDateRangesService, IBugIncidentIssuesCreateInDateRangeService
    {
        private static readonly string[] LABELS_INCIDENTS = new string[] { "incidente", "Incidente", "incidentes", "Incidentes" };

        public BugIncidentIssuesCreateInDateRangeService(ISearchPost searchPost)
            : base(searchPost)
        { }

        protected override JqlBuilder CreateJql(string project, DateTime initDate, DateTime endDate)
            => JqlBuilder.GetInstance()
                         .AddProjectCriteria(project)
                         .AddLabelsCriteria(LABELS_INCIDENTS)
                         .AddBetweenCreatedDateCriteria(initDate, endDate);
    }
}