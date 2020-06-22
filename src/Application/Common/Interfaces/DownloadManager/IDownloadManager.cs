﻿using PlexRipper.Application.Common.Models;

namespace PlexRipper.Application.Common.Interfaces.DownloadManager
{
    public interface IDownloadManager
    {
        int ActiveDownloads { get; }
        int CompletedDownloads { get; }
        int TotalDownloads { get; }
        void StartDownload(DownloadRequest downloadTask);
    }
}