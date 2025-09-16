using Application.DTOs.FootprintEntry;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicastion.Mapping
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<FootprintEntry, FootprintEntryDto>().ReverseMap();
            CreateMap<FootprintEntry, CreateFootprintEntryDto>().ReverseMap();
            CreateMap<FootprintEntry, UpdateFootprintEntryDto>().ReverseMap();
            CreateMap<CreateFootprintEntryDto, UpdateFootprintEntryDto>().ReverseMap();
        }
    }
}
