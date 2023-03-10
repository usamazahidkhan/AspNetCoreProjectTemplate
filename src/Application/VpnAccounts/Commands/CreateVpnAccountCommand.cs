using MediatR;
using System.ComponentModel.DataAnnotations;
using ProjectTemplate.Domain;

namespace ProjectTemplate.Application
{
    public class CreateVpnAccountCommand : IRequest<bool>
    {
        [Required]
        public string userName { get; set; }
        [Required]
        public string password { get; set; }
        public VpnAccountStatus status { get; set; }
    }

    internal class CreateVpnAccountCommandHandler : IRequestHandler<CreateVpnAccountCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDateTime _dateTime;
        private readonly ICurrentUserService currentUser;

        public CreateVpnAccountCommandHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUser, IDateTime dateTime)
        {
            this._unitOfWork = unitOfWork;
            this.currentUser = currentUser;
            _dateTime = dateTime;
        }

        public async Task<bool> Handle(CreateVpnAccountCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginAsync(cancellationToken: cancellationToken);

            var vpnAccount = new VpnAccount(
                request.userName,
                request.password,
                currentUser.UserId,
                default
            );

            await _unitOfWork.VpnAccounts.InsertAsync(vpnAccount, cancellationToken);

            await _unitOfWork.CommitAsync(cancellationToken);

            return true;
        }
    }
}
