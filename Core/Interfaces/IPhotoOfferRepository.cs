using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IPhotoOfferRepository
    {
        Task<PhotoOffer> GetPhotoOfferByIdAsync(int id);
        Task<IReadOnlyList<PhotoOffer>> GetPhotoOffersAsync();
        Task<IReadOnlyList<PhotoOfferCategory>> GetPhotoOffersCategoriesAsync();
    }
}
