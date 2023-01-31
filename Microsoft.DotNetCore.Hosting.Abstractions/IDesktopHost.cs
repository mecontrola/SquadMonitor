﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.DotNetCore.Hosting
{
    /// <summary>
    /// Represents a configured desktop host.
    /// </summary>
    public interface IDesktopHost : IDisposable
    {
        /// <summary>
        /// The <see cref="IServiceProvider"/> for the host.
        /// </summary>
        IServiceProvider Services { get; }

        /// <summary>
        /// Starts listening on the configured addresses.
        /// </summary>
        void Start();

        /// <summary>
        /// Starts listening on the configured addresses.
        /// </summary>
        /// <param name="cancellationToken">Used to abort program start.</param>
        /// <returns>A <see cref="Task"/> that completes when the <see cref="IDesktopHost"/> starts.</returns>
        Task StartAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Attempt to gracefully stop the host.
        /// </summary>
        /// <param name="cancellationToken">Used to indicate when stop should no longer be graceful.</param>
        /// <returns>A <see cref="Task"/> that completes when the <see cref="IDesktopHost"/> stops.</returns>
        Task StopAsync(CancellationToken cancellationToken = default);
    }
}