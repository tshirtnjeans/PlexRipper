﻿using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentResults;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PlexRipper.Application;
using PlexRipper.Data.Common;
using PlexRipper.Domain;

namespace PlexRipper.Data.CQRS.PlexDownloads
{
    public class GetAllDownloadTasksQueryValidator : AbstractValidator<GetAllDownloadTasksQuery> { }

    public class GetAllDownloadTasksQueryHandler : BaseHandler, IRequestHandler<GetAllDownloadTasksQuery, Result<List<DownloadTask>>>
    {
        public GetAllDownloadTasksQueryHandler(PlexRipperDbContext dbContext) : base(dbContext) { }

        public async Task<Result<List<DownloadTask>>> Handle(GetAllDownloadTasksQuery request, CancellationToken cancellationToken)
        {
            var query = _dbContext.DownloadTasks.AsQueryable();

            if (request.IncludeServer)
            {
                query = query.Include(x => x.PlexServer);
            }

            if (request.IncludePlexLibrary)
            {
                query = query.Include(x => x.PlexLibrary);
            }

            if (request.DownloadTaskIds != null && request.DownloadTaskIds.Any())
            {
                query = query.Where(x => request.DownloadTaskIds.Contains(x.Id));
            }

            var downloadList = await query
                .Include(x => x.DownloadWorkerTasks)
                .Include(x => x.DestinationFolder)
                .Include(x => x.DownloadFolder)
                .Include(x => x.PlexServer)
                .Include(x => x.PlexLibrary)
                .ToListAsync(cancellationToken);
            return Result.Ok(downloadList);
        }
    }
}