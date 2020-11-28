using API.Dtos;
using AutoMapper;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<PhotoOffer, PhotoOfferToReturnDto>()
                .ForMember(d => d.PhotoOfferCategory, o => o.MapFrom(s => s.PhotoOfferCategory.Name))
                .ForMember(d => d.PhotoOfferType, o => o.MapFrom(s => s.PhotoOfferType.Name))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<PhotoOfferUrlResolver>());
        }
    }
}
