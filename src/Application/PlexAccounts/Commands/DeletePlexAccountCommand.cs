﻿using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PlexRipper.Application.Common.Interfaces.DataAccess;
using PlexRipper.Domain;
using PlexRipper.Domain.Types;
using System.Threading;
using System.Threading.Tasks;
using FluentResults;

namespace PlexRipper.Application.PlexAccounts
{
    public class DeletePlexAccountCommand : IRequest<Result<bool>>
    {
        public int Id { get; }

        public DeletePlexAccountCommand(int Id)
        {
            this.Id = Id;
        }
    }

    public class DeletePlexAccountValidator : AbstractValidator<DeletePlexAccountCommand>
    {
        public DeletePlexAccountValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }

    public class DeletePlexAccountHandler : IRequestHandler<DeletePlexAccountCommand, Result<bool>>
    {
        private readonly IPlexRipperDbContext _dbContext;

        public DeletePlexAccountHandler(IPlexRipperDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result<bool>> Handle(DeletePlexAccountCommand command, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.PlexAccounts.AsTracking().FirstOrDefaultAsync(x => x.Id == command.Id);

            if (entity == null)
            {
                string msg = $"Entity of type PlexAccount with Id {command.Id} could not be found to be removed";
                Log.Warning(msg);
                Result.Fail(msg);
            }

            _dbContext.PlexAccounts.Remove(entity);
            await _dbContext.SaveChangesAsync();
            Log.Debug($"Deleted PlexAccount with Id: {command.Id} from the database");

            return Result.Ok(true);
        }
    }
}
