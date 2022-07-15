﻿using Stefanini.Core.Extensions;
using Stefanini.ViaReport.Core.Data.Dto;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System;
using Stefanini.ViaReport.Data.Dtos;

namespace Stefanini.ViaReport
{
    public partial class DashboardWindow : Window
    {
        private const string WINDOW_TITLE = "Details";

        private readonly ObservableCollection<DashboardInfoItemDto> dgThroughputDataCollection = new();
        private readonly ObservableCollection<DashboardInfoItemDto> dgLeadTimeDataCollection = new();
        private readonly ObservableCollection<DashboardInfoItemDto> dgCycleTimeDataCollection = new();
        private readonly ObservableCollection<DashboardInfoItemDto> dgQuarterEpicsDataCollection = new();

        public DashboardWindow()
        {
            InitializeComponent();
        }

        public void SetDataColletion(DashboardDto data)
        {
            FillDataGrid(DgThroughput, dgThroughputDataCollection, data.Throughput?.Items ?? Array.Empty<DashboardInfoItemDto>());
            FillDataGrid(DgLeadTime, dgLeadTimeDataCollection, data.LeadTime?.Items ?? Array.Empty<DashboardInfoItemDto>());
            FillDataGrid(DgCycleTime, dgCycleTimeDataCollection, data.CycleTime?.Items ?? Array.Empty<DashboardInfoItemDto>());
            FillDataGrid(DgQuarterEpics, dgQuarterEpicsDataCollection, data.QuarterEpics?.Items ?? Array.Empty<DashboardInfoItemDto>());
        }

        private static void FillDataGrid(DataGrid grid, ICollection<DashboardInfoItemDto> collection, IList<DashboardInfoItemDto> items)
        {
            collection.Clear();
            collection.AddList(items);

            grid.ItemsSource = collection;
        }

        private void DgDataColumnLink_Click(object sender, RoutedEventArgs e)
        {
            var link = e.OriginalSource as Hyperlink;
            var item = link?.DataContext as DashboardInfoItemDto ?? new DashboardInfoItemDto();

            var window = new IssueWindow();
            window.DefineTitle(WINDOW_TITLE);
            window.SetDataColletion((IList<Data.Dtos.IssueDto>)item.Issues);
            window.ShowDialog();
        }
    }
}