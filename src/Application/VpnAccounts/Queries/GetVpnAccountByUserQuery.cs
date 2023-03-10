using AutoMapper;
using MediatR;

namespace ProjectTemplate.Application
{
    public class  GetVpnAccountByUserQuery  : IRequest<VpnAccountDto>
    {
        public string id { get; set; }
    }

    internal class GetVpnAccountByUserQueryHandler : IRequestHandler<GetVpnAccountByUserQuery, VpnAccountDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUserService currentUser;
        private readonly IMapper _mapper;
        
        public GetVpnAccountByUserQueryHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUser, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this.currentUser = currentUser;
            _mapper = mapper;
        }

        public async Task<VpnAccountDto> Handle(GetVpnAccountByUserQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.VpnAccounts.FindByIdAsync(request.id);

            if (entity == null)
            {
                throw new NotFoundException();
            }

            if (entity.userId != currentUser.UserId)
            {
                throw new ForbiddenAccessException();
            }

            return _mapper.Map<VpnAccountDto>(entity);
        }
    }
}
