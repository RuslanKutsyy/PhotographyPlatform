using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Data;
using Core.Interfaces;
using System;
using Core.Specifications;
using API.Dtos;
using System.Linq;
using AutoMapper;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhotoOffersController : BaseAPIController
    {
        private readonly IGenericRepository<PhotoOffer> photooffersRepo;
        private readonly IGenericRepository<PhotoOfferCategory> categoriesRepo;
        private readonly IMapper mapper;

        public PhotoOffersController(IGenericRepository<PhotoOffer> photooffersRepo, IGenericRepository<PhotoOfferCategory> categoriesRepo, IMapper mapper)
        {
            this.photooffersRepo = photooffersRepo;
            this.categoriesRepo = categoriesRepo;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<List<PhotoOffer>>> GetPhotoOffers()
        {
            var spec = new PhotoOffersWithCategoriesSpecification();
            var photoshoots = await photooffersRepo.ListAsync(spec);

            return Ok(mapper.Map<IReadOnlyList<PhotoOffer>, IReadOnlyList<PhotoOfferToReturnDto>>(photoshoots));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PhotoOfferToReturnDto>> GetPhotoOffer(int id)
        {
            var spec = new PhotoOffersWithCategoriesSpecification(id);
            var photooffer = await photooffersRepo.GetEntityWithSpec(spec);

            return mapper.Map<PhotoOffer, PhotoOfferToReturnDto>(photooffer);
        }

        [HttpGet("categories")]
        public async Task<ActionResult<IReadOnlyList<PhotoOfferCategory>>> GetPhotoOfferCategoriesAsync()
        {
            var categories = await categoriesRepo.ListAllAsync();
            return Ok(categories);
        }
    }
}
