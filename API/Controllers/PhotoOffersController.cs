using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Data;
using Core.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhotoOffersController : ControllerBase
    {
        private readonly IPhotoOfferRepository repository;

        public PhotoOffersController(IPhotoOfferRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public async Task<ActionResult<List<PhotoOffer>>> GetPhotoshoots()
        {
            var photoshoots = await repository.GetPhotoOffersAsync();

            return Ok(photoshoots);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PhotoOffer>> GetPhotoshoot(int id)
        {
            return await repository.GetPhotoOfferByIdAsync(id);
        }

        [HttpGet("categories")]
        public async Task<ActionResult<IReadOnlyList<PhotoOfferCategory>>> GetPhotoshootOfferCategoriesAsync()
        {
            var categories = await repository.GetPhotoOffersCategoriesAsync();
            return Ok(categories);
        }
    }
}
