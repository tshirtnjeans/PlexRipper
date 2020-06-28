﻿using PlexRipper.Application.Common.Interfaces.Repositories;
using PlexRipper.Data.Common.Interfaces;
using PlexRipper.Domain.Entities;
using Serilog;

namespace PlexRipper.Data.Repositories
{
    public class FolderPathRepository : Repository<FolderPath>, IFolderPathRepository
    {
        public FolderPathRepository(IPlexRipperDbContext context, ILogger log) : base(context, log) { }

    }
}