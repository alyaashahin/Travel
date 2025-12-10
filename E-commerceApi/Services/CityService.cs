using AutoMapper;
using Travel.DTOs.CityDto;
using Travel.Interfaces;
using Travel.Models;
using Travel.Repository.Interfaces;
using Travel.ResponseModel;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Travel.Services
{
    public class CityService : ICityService
    {
        private readonly IRepository<City> _cityRepository;
        private readonly IMapper _mapper;
        private readonly LocalImageService _localImageService;

        public CityService(IRepository<City> cityRepository , IMapper mapper , LocalImageService localImageService)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
            _localImageService = localImageService;
        }
        public async Task<ResponseModel<CityDto>> CreateCityAsync(CreateCityDto createCityDto)
        {
           var city = new City() { CityName = createCityDto.CityName };

           if(createCityDto.ImageFile != null)
           {
              city.Photo = await _localImageService.UploadImageAsync(createCityDto.ImageFile );
           }

            await _cityRepository.CreateAsync(city);
            var CityDto = _mapper.Map<CityDto>(city);
            return ResponseModel<CityDto>.CreateSuccess(CityDto, "City created successfully ");
        }

        public async Task<ResponseModel<IEnumerable<CityDto>>> GetAllCitiesAsync()
        {
            var cities = await _cityRepository.GetAllAsync();
            var result = _mapper.Map<IEnumerable<CityDto>>(cities);

            if (!result.Any())
                return ResponseModel<IEnumerable<CityDto>>.CreateSuccess(result, "No cities found");

            return ResponseModel<IEnumerable<CityDto>>.CreateSuccess(result, "Cities retrieved successfully");
        }

        public async Task<ResponseModel<CityDto>> GetCityByIdAsync(int id)
        {
            var city = await _cityRepository.GetByIdAsync(id);
            if (city == null)
                return ResponseModel<CityDto>.CreateFailure("City not found");

            var dto = _mapper.Map<CityDto>(city);
            return ResponseModel<CityDto>.CreateSuccess(dto, "City retrieved successfully");
        }

        public async Task<ResponseModel<CityDto>> UpdateCityAsync(int id, CreateCityDto createCityDto)
        {
            var city = await _cityRepository.GetByIdAsync(id);
            if (city == null)
                return ResponseModel<CityDto>.CreateFailure("City not found");

            city.CityName = createCityDto.CityName;

            if (createCityDto.ImageFile != null)
                city.Photo = await _localImageService.UploadImageAsync(createCityDto.ImageFile);

            await _cityRepository.UpdateAsync(city);

            var dto = _mapper.Map<CityDto>(city);
            return ResponseModel<CityDto>.CreateSuccess(dto, "City updated successfully");
        }

        public async Task<ResponseModel<bool>> DeleteCityAsync(int id)
        {
            var city = await _cityRepository.GetByIdAsync(id);
            if (city == null)
                return ResponseModel<bool>.CreateFailure("City not found");

            await _cityRepository.DeleteAsync(city);
            return ResponseModel<bool>.CreateSuccess(true, "City deleted successfully");
        }

        public async Task<ResponseModel<IEnumerable<CityDto>>> SearchCitiesByNameAsync(string name)
        {
            var cities = await _cityRepository.FindAsync(c => c.CityName.Contains(name));
            var result = _mapper.Map<IEnumerable<CityDto>>(cities);

            if (!result.Any())
                return ResponseModel<IEnumerable<CityDto>>.CreateSuccess(result, "No matching cities found");

            return ResponseModel<IEnumerable<CityDto>>.CreateSuccess(result, "Search result retrieved successfully");
        }
    }
}
