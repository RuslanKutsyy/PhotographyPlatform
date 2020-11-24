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

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhotoOffersController : ControllerBase
    {
        private readonly IGenericRepository<PhotoOffer> photooffersRepo;
        private readonly IGenericRepository<PhotoOfferCategory> categoriesRepo;

        public PhotoOffersController(IGenericRepository<PhotoOffer> photooffersRepo, IGenericRepository<PhotoOfferCategory> categoriesRepo)
        {
            this.photooffersRepo = photooffersRepo;
            this.categoriesRepo = categoriesRepo;
        }
        [HttpGet]
        public async Task<ActionResult<List<PhotoOffer>>> GetPhotoOffers()
        {
            var spec = new PhotoOffersWithCategoriesSpecification();
            var photoshoots = await photooffersRepo.ListAsync(spec);

            return Ok(photoshoots.Select(x => new PhotoOfferToReturnDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                Duration = x.Duration,
                PictureUrl = x.PictureUrl,
                NumberOfPhotos = x.NumberOfPhotos,
                IsAlbumIncluded = x.IsAlbumIncluded,
                PhotoOfferCategory = x.PhotoOfferCategory.Name
            }).ToList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PhotoOfferToReturnDto>> GetPhotoOffer(int id)
        {
            var spec = new PhotoOffersWithCategoriesSpecification(id);
            var photooffer = await photooffersRepo.GetEntityWithSpec(spec);

            return new PhotoOfferToReturnDto
            {
                Id = photooffer.Id,
                Name = photooffer.Name,
                Description = photooffer.Description,
                Price = photooffer.Price,
                Duration = photooffer.Duration,
                PictureUrl = photooffer.PictureUrl,
                NumberOfPhotos = photooffer.NumberOfPhotos,
                IsAlbumIncluded = photooffer.IsAlbumIncluded,
                PhotoOfferCategory = photooffer.PhotoOfferCategory.Name
            };
        }

        [HttpGet("categories")]
        public async Task<ActionResult<IReadOnlyList<PhotoOfferCategory>>> GetPhotoOfferCategoriesAsync()
        {
            var categories = await categoriesRepo.ListAllAsync();
            return Ok(categories);
        }
    }
}
