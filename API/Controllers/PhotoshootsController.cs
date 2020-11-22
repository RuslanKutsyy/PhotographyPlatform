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
    public class PhotoshootsController : ControllerBase
    {
        private readonly IPhotoshootRepository repository;

        public PhotoshootsController(IPhotoshootRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public async Task<ActionResult<List<Photoshoot>>> GetPhotoshoots()
        {
            var photoshoots = await repository.GetProductsAsync();

            return Ok(photoshoots);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Photoshoot>> GetPhotoshoot(int id)
        {
            return await repository.GetPhotoshootByIdAsync(id);
        }
    }
}
