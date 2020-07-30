﻿using FluentResults;
using FluentValidation;
using MediatR;
using PlexRipper.Application.Common.Interfaces.DataAccess;
using PlexRipper.Domain.Base;
using PlexRipper.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PlexRipper.Application.FolderPaths.Queries
{
    public class GetFolderPathByIdQuery : IRequest<Result<FolderPath>>
    {
        public GetFolderPathByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }

    public class GetFolderPathByIdQueryValidator : AbstractValidator<GetFolderPathByIdQuery>
    {
        public GetFolderPathByIdQueryValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }


    public class GetFolderPathByIdQueryHandler : BaseHandler, IRequestHandler<GetFolderPathByIdQuery, Result<FolderPath>>
    {
        private readonly IPlexRipperDbContext _dbContext;

        public GetFolderPathByIdQueryHandler(IPlexRipperDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result<FolderPath>> Handle(GetFolderPathByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await ValidateAsync<GetFolderPathByIdQuery, GetFolderPathByIdQueryValidator>(request);
            if (result.IsFailed) return result;

            var folderPath = await _dbContext.FolderPaths.FindAsync(request.Id);
            return ReturnResult(folderPath, request.Id);

        }
    }
}
