﻿using AutoMapper;
using PlexRipper.Domain.Entities;
using PlexRipper.WebAPI.Common.DTO;
using System.Linq;

namespace PlexRipper.WebAPI.Common.Mappings
{
    public class WebApiMappingProfile : Profile
    {
        public WebApiMappingProfile()
        {
            //AccountDTO <-> Account
            CreateMap<AccountDTO, Account>(MemberList.Destination).ReverseMap();
            //PlexAccountDTO <-> PlexAccount
            CreateMap<PlexAccountDTO, PlexAccount>(MemberList.None)
                .ForMember(x => x.PlexAccountServers,
                    opt => opt.Ignore());
            CreateMap<PlexAccount, PlexAccountDTO>(MemberList.Destination)
                .ForMember(dto => dto.PlexServers,
                    opt => opt.MapFrom(x => x.PlexAccountServers.ToArray().Select(y => y.PlexServer).ToList()));
        }
    }
}