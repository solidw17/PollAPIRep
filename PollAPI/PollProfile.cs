using AutoMapper;
using PollAPI.Entities;
using PollAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PollAPI
{
    public class PollProfile : Profile
    {
        public PollProfile()
        {
            CreateMap<Poll, PollDto>()
                .ForMember(p => p.Poll_id, map => map.MapFrom(o => o.Id))
                .ForMember(p => p.Poll_description, map => map.MapFrom(o => o.Description));

            CreateMap<Option, OptionDto>()
                .ForMember(o => o.Option_id, map => map.MapFrom(p => p.Id))
                .ForMember(o => o.Option_description, map => map.MapFrom(p => p.Description));

            CreateMap<PollPostDto, Poll>()
                .ForMember(p => p.Description, map => map.MapFrom(o => o.Poll_description));

            CreateMap<OptionPostDto, Option>();

            CreateMap<Poll, PollIdDto>()
                .ForMember(p => p.Poll_id, map => map.MapFrom(o => o.Id));

            CreateMap<Poll, PollStatsDto>()
                .ForMember(p => p.Votes, map => map.MapFrom(o => o.Options));

            CreateMap<Option, OptionStatsDto>()
                .ForMember(o => o.Option_id, map => map.MapFrom(p => p.Id));
        }
    }
}
