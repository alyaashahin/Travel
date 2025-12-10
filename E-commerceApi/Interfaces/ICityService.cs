using Travel.DTOs.CityDto;
using Travel.Models;
using Travel.ResponseModel;

namespace Travel.Interfaces
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
