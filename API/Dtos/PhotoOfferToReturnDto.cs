using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class PhotoOfferToReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Duration { get; set; }
        public string PictureUrl { get; set; }
        public int NumberOfPhotos { get; set; }
        public bool IsAlbumIncluded { get; set; }
        public string PhotoOfferCategory { get; set; }
    }
}