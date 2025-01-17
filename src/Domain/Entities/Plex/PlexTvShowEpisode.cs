﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlexRipper.Domain
{
    public class PlexTvShowEpisode : PlexMedia, IToDownloadTask
    {
        /// <summary>
        /// The PlexKey of the <see cref="PlexTvShowSeason"/> this belongs too.
        /// </summary>
        public int ParentKey { get; set; }

        #region Relationships

        public PlexTvShow TvShow { get; set; }

        public int TvShowId { get; set; }

        public PlexTvShowSeason TvShowSeason { get; set; }

        public int TvShowSeasonId { get; set; }

        #endregion

        #region Helpers

        [NotMapped]
        public List<PlexMediaData> EpisodeData => MediaData.MediaData;

        [NotMapped]
        public override PlexMediaType Type => PlexMediaType.Episode;

        #endregion

        public List<DownloadTask> CreateDownloadTasks()
        {
            var downloadTask = CreateBaseDownloadTask();
            downloadTask.MediaType = Type;
            downloadTask.MetaData.TvShowTitle = TvShowSeason?.TvShow?.Title ?? string.Empty;
            downloadTask.MetaData.TvShowSeasonTitle = TvShowSeason?.Title ?? string.Empty;
            downloadTask.MetaData.TvShowEpisodeTitle = Title;
            downloadTask.MetaData.MediaData = EpisodeData;

            downloadTask.MetaData.TvShowKey = TvShowSeason?.TvShow?.Key ?? 0;
            downloadTask.MetaData.TvShowSeasonKey = ParentKey;
            downloadTask.MetaData.TvShowEpisodeKey = Key;

            return new List<DownloadTask>
            {
                downloadTask,
            };
        }
    }
}