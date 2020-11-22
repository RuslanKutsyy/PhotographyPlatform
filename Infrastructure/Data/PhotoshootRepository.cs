using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class PhotoshootRepository : IPhotoshootRepository
    {
        private readonly StoreContext storeContext;

        public PhotoshootRepository(StoreContext storeContext)
        {
            this.storeContext = storeContext;
        }

        public async Task<Photoshoot> GetPhotoshootByIdAsync(int id)
        {
            return await storeContext.Photoshoots.FindAsync(id);
        }

        public async Task<IReadOnlyList<Photoshoot>> GetProductsAsync()
        {
            return await storeContext.Photoshoots.ToListAsync();
        }
    }
}
