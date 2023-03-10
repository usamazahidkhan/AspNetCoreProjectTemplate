using MediatR;
using Microsoft.Extensions.Logging;
using ProjectTemplate.Domain;

namespace ProjectTemplate.Application
{
    public class CreateVpnAccountDomainEventHandler : INotificationHandler<VpnAccountCreateDomainEvent>
    {
        private readonly ILogger<VpnAccountCreateDomainEvent> _logger;

        public CreateVpnAccountDomainEventHandler(ILogger<VpnAccountCreateDomainEvent> logger)
        {
            _logger = logger;
        }

        public Task Handle(VpnAccountCreateDomainEvent notification, CancellationToken cancellationToken)
        {
            //throw new Exception();

            _logger.LogInformation("CleanArchitecture Domain Event: {DomainEvent}", notification.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
