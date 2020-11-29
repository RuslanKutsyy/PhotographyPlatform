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
using API.Errors;
using Microsoft.AspNetCore.Http;
using API.Helpers;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhotoOffersController : BaseAPIController
    {
        private readonly IGenericRepository<PhotoOffer> photooffersRepo;
        private readonly IGenericRepository<PhotoOfferCategory> categoriesRepo;
        private readonly IGenericRepository<PhotoOfferType> typeRepo;
        private readonly IMapper mapper;

        public PhotoOffersController(IGenericRepository<PhotoOffer> photooffersRepo, IGenericRepository<PhotoOfferCategory> categoriesRepo, IGenericRepository<PhotoOfferType> typeRepo, IMapper mapper)
        {
            this.photooffersRepo = photooffersRepo;
            this.categoriesRepo = categoriesRepo;
            this.typeRepo = typeRepo;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<Pagination<PhotoOffer>>> GetPhotoOffers([FromQuery] PhotoOfferSpecParams photoOfferParams)
        {
            var spec = new PhotoOffersWithCategoriesAndTypesSpecification(photoOfferParams);
            var countSpec = new PhotoOfferWithFiltersForCountSpecification(photoOfferParams);
            var totalItems = await photooffersRepo.CountAsync(countSpec);

            var photoshoots = await photooffersRepo.ListAsync(spec);

            var data = mapper.Map<IReadOnlyList<PhotoOffer>, IReadOnlyList<PhotoOfferToReturnDto>>(photoshoots);

            return Ok(new Pagination<PhotoOfferToReturnDto>(photoOfferParams.PageIndex, photoOfferParams.PageSize, totalItems, data));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PhotoOfferToReturnDto>> GetPhotoOffer(int id)
        {
            var spec = new PhotoOffersWithCategoriesAndTypesSpecification(id);
            var photooffer = await photooffersRepo.GetEntityWithSpec(spec);

            if (photooffer == null)
            {
                return NotFound(new ApiResponse(404));
            }

            return mapper.Map<PhotoOffer, PhotoOfferToReturnDto>(photooffer);
        }

        [HttpGet("categories")]
        public async Task<ActionResult<IReadOnlyList<PhotoOfferCategory>>> GetPhotoOfferCategoriesAsync()
        {
            var categories = await categoriesRepo.ListAllAsync();
            return Ok(categories);
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<PhotoOfferCategory>>> GetPhotoOfferTypesAsync()
        {
            var types = await typeRepo.ListAllAsync();
            return Ok(types);
        }
    }
}
