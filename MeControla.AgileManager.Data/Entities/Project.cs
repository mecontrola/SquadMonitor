﻿using MeControla.Core.Data.Entities;
using System;
using System.Collections.Generic;

namespace MeControla.AgileManager.Data.Entities
{
    public class Project : IEntity
    {
        public long Id { get; set; }
        public Guid Uuid { get; set; }
        public long Key { get; set; }
        public string Name { get; set; }
        public long ProjectCategoryId { get; set; }
        public bool Selected { get; set; }
        public ProjectCategory ProjectCategory { get; set; }
        public IList<Issue> Issues { get; set; }
        public IList<PreferenceClassOfService> PreferenceClassOfService { get; set; }
        public IList<PreferenceCustomField> PreferenceCustomField { get; set; }
        public IList<PreferenceIssueType> PreferenceIssueType { get; set; }
        public IList<PreferenceStatusCategory> PreferenceStatusCategory { get; set; }
        public IList<PreferenceStatus> PreferenceStatus { get; set; }
    }
}