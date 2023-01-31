﻿using MeControla.AgileManager.Data.Entities;
using MeControla.Core.Tools;

namespace MeControla.AgileManager.DataStorage.Schemas
{
    internal static class PreferenceIssueTypeSchema
    {
        private const string PREFIX_TABLE = "am";
        private const string PREFIX_COLUMN = "pit";

        private static TableMetadata<PreferenceIssueType> Metadata { get; } = new(PREFIX_TABLE, PREFIX_COLUMN);

        public static string Table { get; } = Metadata.GetTableName();
        public static string Schema { get; } = "agile_manager";

        public static class Columns
        {
            public static string Id { get; } = Metadata.GetColumnName(x => x.Id);
            public static string Uuid { get; } = Metadata.GetColumnName(x => x.Uuid);
            public static string Type { get; } = Metadata.GetColumnName(x => x.Type);
            public static string Name { get; } = Metadata.GetColumnName(x => x.Name);
            public static string IssueTypeId { get; } = IssueTypeSchema.Columns.Id;
            public static string ProjectId { get; } = ProjectSchema.Columns.Id;
        }
    }
}