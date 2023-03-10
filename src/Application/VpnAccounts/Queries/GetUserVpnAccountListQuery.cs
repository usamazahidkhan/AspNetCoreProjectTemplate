using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ProjectTemplate.Application
{
    public class GetVpnAccountListByUserQuery : IRequest<List<VpnAccountDto>> 
    { }

    internal class GetVpnAccountByIdQueryHandler : IRequestHandler<GetVpnAccountListByUserQuery, List<VpnAccountDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUserService currentUser;
        private readonly IMapper _mapper;

        public GetVpnAccountByIdQueryHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUser, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this.currentUser = currentUser;
            _mapper = mapper;
        }

        public async Task<List<VpnAccountDto>> Handle(GetVpnAccountListByUserQuery request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.VpnAccounts.QueryAll()
                            .Where(x => x.userId == currentUser.UserId)
                            .ToListAsync(cancellationToken);

            return _mapper.Map<List<VpnAccountDto>>(entities);
        }
    }
}
