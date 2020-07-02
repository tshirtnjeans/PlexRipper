﻿using FluentResults;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace PlexRipper.Domain.Behavior.Pipelines
{
    public class ValidationPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TResponse : class
        where TRequest : IRequest<TResponse>
    {
        private readonly IValidator<TRequest> _compositeValidator;

        public ValidationPipeline(IValidator<TRequest> compositeValidator)
        {
            _compositeValidator = compositeValidator;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            // Pre
            var result = await _compositeValidator.ValidateAsync(request, cancellationToken);

            if (!result.IsValid)
            {
                Error error = new Error();
                var responseType = typeof(TResponse);

                foreach (var validationFailure in result.Errors)
                {
                    Log.Warning($"{responseType} - {validationFailure.ErrorMessage}");
                    error.Reasons.Add(new Error(validationFailure.ErrorMessage));
                }

                return FluentResults.Result.Fail(error) as TResponse;
            }

            return await next();
        }
    }
}
