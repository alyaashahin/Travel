using E_commerceApi.DTOs.CityDto;
using E_commerceApi.Models;
using E_commerceApi.ResponseModel;

namespace E_commerceApi.Interfaces
{
    public interface ICityService
    {
        public Task<ResponseModel<IEnumerable<CityDto>>> GetAllCitiesAsync();
        public Task<ResponseModel<CityDto>> GetCityByIdAsync(int id);
        public Task<ResponseModel<CityDto>> CreateCityAsync(CreateCityDto createCityDto);
        public Task<ResponseModel<CityDto>> UpdateCityAsync(int id, CreateCityDto createCityDto);
        public Task<ResponseModel<bool>> DeleteCityAsync(int id);
        public Task<ResponseModel<IEnumerable<CityDto>>> SearchCitiesByNameAsync(string name);
    }
}
