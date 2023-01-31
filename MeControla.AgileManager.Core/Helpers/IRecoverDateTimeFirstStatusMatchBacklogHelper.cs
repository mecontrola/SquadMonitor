﻿using MeControla.AgileManager.Integrations.Jira.Data.Dtos;
using System;
using System.Collections.Generic;

namespace MeControla.AgileManager.Core.Helpers
{
    public interface IRecoverDateTimeFirstStatusMatchBacklogHelper
    {
        DateTime? GetDateTime(ChangelogDto changelog, IList<string> statuses);
    }
}