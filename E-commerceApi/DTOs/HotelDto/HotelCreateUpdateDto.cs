namespace Travel.DTOs.HotelDto
{
    public class HotelCreateUpdateDto
   {
        public string Name { get; set; } 
        public string? Address { get; set; }
        public string? ZipCode { get; set; }
        public string? Description { get; set; }
        public decimal? StarRating { get; set; }
        public string? Amenities { get; set; }
        public List<IFormFile>? ImageFiles { get; set; } 
        public int? CityId { get; set; }
    }
}
