using AutoMapper;
using E_commerceApi.DTOs.CityDto;
using E_commerceApi.DTOs.HotelDto;
using E_commerceApi.Models;

namespace E_commerceApi.Mapping
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
