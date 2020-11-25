using API.Dtos;
using AutoMapper;
using Core.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers
{
    public class PhotoOfferUrlResolver : IValueResolver<PhotoOffer, PhotoOfferToReturnDto, string>
    {
        private readonly IConfiguration config;

        public PhotoOfferUrlResolver(IConfiguration config)
        {
            this.config = config;
        }

        public string Resolve(PhotoOffer source, PhotoOfferToReturnDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                return config["ApiUrl"] + source.PictureUrl;
            }

            return null;
        }
    }
}
