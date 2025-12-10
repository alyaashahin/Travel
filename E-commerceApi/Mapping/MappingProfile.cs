using AutoMapper;
using Travel.DTOs.CityDto;
using Travel.DTOs.HotelDto;
using Travel.Models;

namespace Travel.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<City, CityDto>().ReverseMap();
            CreateMap<City, CreateCityDto>().ReverseMap();

            CreateMap<HotelCreateUpdateDto, Hotel>().ForMember(dest => dest.ImageGallery, opt => opt.Ignore()); ;
            CreateMap<Hotel , HotelDto>().ReverseMap();
        }
    }
}
