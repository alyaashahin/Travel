namespace Travel.DTOs.CityDto
{
    public class CreateCityDto
    {
        public string CityName { get; set; }
        public IFormFile? ImageFile { get; set; }

    }
}
