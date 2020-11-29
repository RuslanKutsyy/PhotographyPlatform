using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Specifications
{
    public class PhotoOfferWithFiltersForCountSpecification : BaseSpecification<PhotoOffer>
    {
        public PhotoOfferWithFiltersForCountSpecification(PhotoOfferSpecParams photoOfferParams)
            : base(x => 
            (!photoOfferParams.CategoryId.HasValue || x.PhotoOfferCategoryId == photoOfferParams.CategoryId) && 
            (!photoOfferParams.TypeId.HasValue || x.PhotoOfferTypeId == photoOfferParams.TypeId))
        {
        }
    }
}
