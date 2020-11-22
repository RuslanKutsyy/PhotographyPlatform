namespace Core.Entities
{
    public class Photoshoot : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public PhotoshootCategory PhotoshootCategory { get; set; }
        public int PhotoshootCategoryId { get; set; }
    }
}
