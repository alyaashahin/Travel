namespace Travel.DTOs.HotelDto
{
    public class HotelDto
    {
        public int HotelId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Address { get; set; }
        public string? ZipCode { get; set; }
        public string? Description { get; set; }
        public decimal? StarRating { get; set; }
        public string? Amenities { get; set; }
        public List<string>? ImageGallery { get; set; }
        public int? CityId { get; set; }
    }
}
