using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectTemplate.Domain;

namespace ProjectTemplate.Application
{
    internal class VpnAccountMapping : Profile
    {
        public VpnAccountMapping()
        {
            CreateMap<VpnAccount, VpnAccountDto>();
        }
    }
}
