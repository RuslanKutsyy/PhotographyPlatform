namespace Core.Entities
{
    public class PhotoOffer : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Duration { get; set; }
        public string PictureUrl { get; set; }
        public int NumberOfPhotos { get; set; }
        public bool IsAlbumIncluded { get; set; }
        public PhotoOfferCategory PhotoOfferCategory { get; set; }
        public int PhotoOfferCategoryId { get; set; }
        public PhotoOfferType PhotoOfferType { get; set; }
        public int PhotoOfferTypeId { get; set; }
    }
}
