﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentResults;
using PlexRipper.Application.Common.WebApi;
using PlexRipper.Domain;

namespace PlexRipper.Application.Common
{
    public interface IPlexLibraryService
    {
        /// <summary>
        /// Retrieves the new media metadata from the PlexApi and stores it in the database.
        /// </summary>
        /// <param name="plexLibraryId">The id of the <see cref="PlexLibrary"/> to retrieve.</param>
        /// <param name="progressAction">The action to call for a progress update.</param>
        /// <returns>Returns the PlexLibrary with the containing media.</returns>
        Task<Result<PlexLibrary>> RefreshLibraryMediaAsync(int plexLibraryId, Action<LibraryProgress> progressAction = null);

        /// <summary>
        /// Retrieve the latest <see cref="PlexLibrary">PlexLibraries</see> for this <see cref="PlexServer"/> which the <see cref="PlexAccount"/> has access to and update the database.
        /// </summary>
        /// <param name="plexAccount"></param>
        /// <param name="plexServer"></param>
        /// <returns>If successful.</returns>
        Task<Result> RetrieveAccessibleLibrariesAsync(PlexAccount plexAccount, PlexServer plexServer);

        /// <summary>
        /// Returns the PlexLibrary by the Id, will refresh if the library has no media assigned.
        /// </summary>
        /// <param name="libraryId">The id of the <see cref="PlexLibrary"/> to retrieve.</param>
        /// <param name="topLevelMediaOnly"></param>
        /// <returns>Valid result if found.</returns>
        Task<Result<PlexLibrary>> GetPlexLibraryAsync(int libraryId, bool topLevelMediaOnly = false);

        Task<Result<PlexServer>> GetPlexLibraryInServerAsync(int libraryId, bool topLevelMediaOnly = false);

        Task<Result<List<PlexLibrary>>> GetAllPlexLibrariesAsync();

        Task<Result> UpdateDefaultDestinationLibrary(int libraryId, int folderPathId);
    }
}