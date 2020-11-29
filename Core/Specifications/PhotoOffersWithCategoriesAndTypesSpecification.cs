using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Specifications
{
    public class PhotoOffersWithCategoriesAndTypesSpecification : BaseSpecification<PhotoOffer>
    {
        public PhotoOffersWithCategoriesAndTypesSpecification(PhotoOfferSpecParams photoOfferParams)
            : base(x => 
            (string.IsNullOrEmpty(photoOfferParams.Search) || x.Name.ToLower().Contains(photoOfferParams.Search)) &&
            (!photoOfferParams.CategoryId.HasValue || x.PhotoOfferCategoryId == photoOfferParams.CategoryId) &&
            (!photoOfferParams.TypeId.HasValue || x.PhotoOfferTypeId == photoOfferParams.TypeId))
        {
            AddInclude(x => x.PhotoOfferCategory);
            AddInclude(x => x.PhotoOfferType);
            AddOrderBy(x => x.Name);
            ApplyPaging(photoOfferParams.PageSize * (photoOfferParams.PageIndex - 1), photoOfferParams.PageSize);

            if (!string.IsNullOrEmpty(photoOfferParams.Sort))
            {
                switch (photoOfferParams.Sort)
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
