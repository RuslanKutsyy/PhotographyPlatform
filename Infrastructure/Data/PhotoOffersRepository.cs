using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class PhotoOffersRepository : IPhotoOfferRepository
    {
        private readonly StoreContext storeContext;

        public PhotoOffersRepository(StoreContext storeContext)
        {
            this.storeContext = storeContext;
        }

        public async Task<PhotoOffer> GetPhotoOfferByIdAsync(int id)
        {
            return await storeContext.PhotoOffers.Include(p => p.PhotoOfferCategory).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<PhotoOffer>> GetPhotoOffersAsync()
        {
            return await storeContext.PhotoOffers.Include(p => p.PhotoOfferCategory).ToListAsync();
        }

        public async Task<IReadOnlyList<PhotoOfferCategory>> GetPhotoOffersCategoriesAsync()
        {
            return await storeContext.PhotoOffersCategories.ToListAsync();
        }
    }
}
