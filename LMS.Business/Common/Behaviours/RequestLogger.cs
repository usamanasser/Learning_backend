using System.Threading;
using System.Threading.Tasks;
using LMS.Domain.Interface;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace LMS.Business.Common.Behaviours
{
    public class RequestLogger<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger _logger;
        private readonly string _userName;

        public RequestLogger(ILogger<TRequest> logger, IUserHttpContextProvider contextProvider)
        {
            _logger = logger;
            _userName = contextProvider.GetUserName();
        }

        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var name = typeof(TRequest).Name;

            _logger.LogInformation("FrontLine Request: {Name} {@UserId} {@Request}",
                name, _userName, request);

            return Task.CompletedTask;
        }
    }
}
