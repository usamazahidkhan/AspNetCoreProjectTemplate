using MediatR;
using ProjectTemplate.Domain;

namespace ProjectTemplate.Application
{
    public class UserAccountSetupCommand : IRequest<bool>
    {
        public string createdUserId { get; set; }
    }

    internal class UserAccountSetupCommandHandler : IRequestHandler<UserAccountSetupCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserAccountSetupCommandHandler(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UserAccountSetupCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginAsync(cancellationToken: cancellationToken);

            var userId = request.createdUserId;

            await _unitOfWork.UserWallets.InsertAsync(new(userId), cancellationToken);

            await _unitOfWork.UserAccountDetails.InsertAsync(new(userId), cancellationToken);

            await _unitOfWork.CommitAsync(cancellationToken);

            return true;
        }
    }
}
