using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Specifications
{
    public class PhotoOffersWithCategoriesAndTypesSpecification : BaseSpecification<PhotoOffer>
    {
        public PhotoOffersWithCategoriesAndTypesSpecification(string sort)
        {
            AddInclude(x => x.PhotoOfferCategory);
            AddInclude(x => x.PhotoOfferType);
            AddOrderBy(x => x.Name);

            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
                {
                    case "priceAsc":
                        {
                            AddOrderBy(p => p.Price);
                            break;
                        }
                    case "priceDesc":
                        {
                            AddOrderByDescending(p => p.Price);
                            break;
                        }

                    default:
                        AddOrderBy(n => n.Name);
                        break;
                }
            }
        }

        public PhotoOffersWithCategoriesAndTypesSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.PhotoOfferCategory);
            AddInclude(x => x.PhotoOfferType);
        }
    }
}
