using MediatR;
using System.ComponentModel.DataAnnotations;
using ProjectTemplate.Domain;

namespace ProjectTemplate.Application
{
    public class UpdateVpnAccountByUserCommand : IRequest<bool>
    {
        public string id { get; set; }
        public DateTime? expiredOn { get; set; }
    }

    internal class UpdateVpnAccountCommandHandler : IRequestHandler<UpdateVpnAccountByUserCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDateTime _dateTime;
        private readonly ICurrentUserService currentUser;

        public UpdateVpnAccountCommandHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUser, IDateTime dateTime)
        {
            this._unitOfWork = unitOfWork;
            this.currentUser = currentUser;
            _dateTime = dateTime;
        }

        public async Task<bool> Handle(UpdateVpnAccountByUserCommand request, CancellationToken cancellationToken)
        {
            if (request.expiredOn <= _dateTime.Now)
            {
                throw new ValidationException(nameof(request.expiredOn), "expiry date should be in future.");
            }

            await _unitOfWork.BeginAsync(cancellationToken: cancellationToken);

            var vpnAccount = await _unitOfWork.VpnAccounts.FindByIdAsync(request.id, cancellationToken);

            if (vpnAccount.userId != currentUser.UserId)
            {
                throw new ForbiddenAccessException();
            }

            vpnAccount.expiredOn = request.expiredOn;

            await _unitOfWork.VpnAccounts.UpdateAsync(vpnAccount, cancellationToken);

            await _unitOfWork.CommitAsync(cancellationToken);

            return true;
        }
    }
}
