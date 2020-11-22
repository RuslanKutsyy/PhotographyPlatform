using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Data;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhotoshootsController : ControllerBase
    {
        private readonly StoreContext context;

        public PhotoshootsController(StoreContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Photoshoot>>> GetPhotoshoots()
        {
            var photoshoots = await context.Photoshoots.ToListAsync();

            return photoshoots;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Photoshoot>> GetPhotoshoot(int id)
        {
            return await context.Photoshoots.FindAsync(id);
        }
    }
}
