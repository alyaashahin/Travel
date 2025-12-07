using E_commerceApi.DTOs.HotelDto;
using E_commerceApi.ResponseModel;

namespace E_commerceApi.Interfaces
{
    public interface IHotelService
    {
        public Task<ResponseModel<IEnumerable<HotelDto>>> GetAllHotelsAsync();
        public Task<ResponseModel<HotelDto>> GetHotelByIdAsync(int id);
        public Task<ResponseModel<HotelDto>> CreateHotelAsync(HotelCreateUpdateDto createHotelDto);
        public Task<ResponseModel<HotelDto>> UpdateHotelAsync(int id, HotelCreateUpdateDto createHotelDto);
        public Task<ResponseModel<bool>> DeleteHotelAsync(int id);
        public Task<ResponseModel<IEnumerable<HotelDto>>> SearchHotelsByNameAsync(string name);
    }
}
