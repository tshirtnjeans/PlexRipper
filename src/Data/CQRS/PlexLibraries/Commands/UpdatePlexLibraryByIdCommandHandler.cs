﻿using System;
using System.Threading;
using System.Threading.Tasks;
using FluentResultExtensions.lib;
using FluentResults;
using FluentValidation;
using Logging;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PlexRipper.Application.PlexLibraries;
using PlexRipper.Data.Common;
using PlexRipper.Domain;

namespace PlexRipper.Data.CQRS.PlexLibraries
{
    public class UpdatePlexLibraryByIdCommandValidator : AbstractValidator<UpdatePlexLibraryByIdCommand>
    {
        public UpdatePlexLibraryByIdCommandValidator()
        {
            RuleFor(x => x.PlexLibrary).NotNull();
            RuleFor(x => x.PlexLibrary.Id).GreaterThan(0);
            RuleFor(x => x.PlexLibrary.PlexServerId).GreaterThan(0);
            RuleFor(x => x.PlexLibrary.Type).NotEqual(PlexMediaType.None);
        }
    }

    public class UpdatePlexLibraryByIdCommandHandler : BaseHandler, IRequestHandler<UpdatePlexLibraryByIdCommand, Result<bool>>
    {
        public UpdatePlexLibraryByIdCommandHandler(PlexRipperDbContext dbContext) : base(dbContext) { }

        public async Task<Result<bool>> Handle(UpdatePlexLibraryByIdCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var plexLibraryDb = await _dbContext.PlexLibraries.AsTracking().FirstOrDefaultAsync(x => x.Id == command.PlexLibrary.Id);

                _dbContext.Entry(plexLibraryDb).CurrentValues.SetValues(command.PlexLibrary);

                await _dbContext.SaveChangesAsync(cancellationToken);
                return Result.Ok(true);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return Result.Fail(new ExceptionalError(e));
            }
        }
    }
}