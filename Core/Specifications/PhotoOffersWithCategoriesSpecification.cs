using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Specifications
{
    public class PhotoOffersWithCategoriesSpecification : BaseSpecification<PhotoOffer>
    {
        public PhotoOffersWithCategoriesSpecification()
        {
            AddInclude(x => x.PhotoOfferCategory);
        }

        public PhotoOffersWithCategoriesSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.PhotoOfferCategory);
        }
    }
}
