using AutoMapper;
using E_commerceApi.DTOs.HotelDto;
using E_commerceApi.Interfaces;
using E_commerceApi.Models;
using E_commerceApi.Repository.Interfaces;
using E_commerceApi.ResponseModel;

namespace E_commerceApi.Services
{
    public class HotelService : IHotelService
    {
        private readonly IRepository<Hotel> _hotelRepository;
        private readonly IMapper _mapper;
        private readonly LocalImageService _localImageService;

        public HotelService(IRepository<Hotel> hotelRepository, IMapper mapper, LocalImageService localImageService)
        {
            _hotelRepository = hotelRepository;
            _mapper = mapper;
            _localImageService = localImageService;
        }
        public async Task<ResponseModel<HotelDto>> CreateHotelAsync(HotelCreateUpdateDto createHotelDto)
        {
            var hotel = new Hotel()
            {
                Name = createHotelDto.Name,
                Address = createHotelDto.Address,
                ZipCode = createHotelDto.ZipCode,
                Description = createHotelDto.Description,
                StarRating = createHotelDto.StarRating,
                Amenities = createHotelDto.Amenities,
                CityId = createHotelDto.CityId,
                ImageGallery = new List<string>()
            };

            if (createHotelDto.ImageFiles != null && createHotelDto.ImageFiles.Any())
            {
                foreach (var file in createHotelDto.ImageFiles)
                {
                    var url = await _localImageService.UploadImageAsync(file);
                    hotel.ImageGallery.Add(url);
                }
            }

            await _hotelRepository.CreateAsync(hotel);
            var dto = _mapper.Map<HotelDto>(hotel);

            return ResponseModel<HotelDto>.CreateSuccess(dto, "Hotel created successfully");
        }

        public async Task<ResponseModel<IEnumerable<HotelDto>>> GetAllHotelsAsync()
        {
            var hotels = await _hotelRepository.GetAllAsync();
            var result = _mapper.Map<IEnumerable<HotelDto>>(hotels);

            return ResponseModel<IEnumerable<HotelDto>>.CreateSuccess(result, "Hotels retrieved successfully");
        }

        public async Task<ResponseModel<HotelDto>> GetHotelByIdAsync(int id)
        {
            var hotel = await _hotelRepository.GetByIdAsync(id);
            if (hotel == null)
                return ResponseModel<HotelDto>.CreateFailure("Hotel not found");

            var dto = _mapper.Map<HotelDto>(hotel);
            return ResponseModel<HotelDto>.CreateSuccess(dto, "Hotel retrieved successfully");
        }


        public async Task<ResponseModel<HotelDto>> UpdateHotelAsync(int id, HotelCreateUpdateDto createHotelDto)
        {
            var hotel = await _hotelRepository.GetByIdAsync(id);
            if (hotel == null)
                return ResponseModel<HotelDto>.CreateFailure("Hotel not found");

            hotel.Name = createHotelDto.Name;
            hotel.Address = createHotelDto.Address;
            hotel.ZipCode = createHotelDto.ZipCode;
            hotel.Description = createHotelDto.Description;
            hotel.StarRating = createHotelDto.StarRating;
            hotel.Amenities = createHotelDto.Amenities;
            hotel.CityId = createHotelDto.CityId;

            if (createHotelDto.ImageFiles != null && createHotelDto.ImageFiles.Any())
            {
                hotel.ImageGallery = new List<string>();
                foreach (var file in createHotelDto.ImageFiles)
                {
                    var url = await _localImageService.UploadImageAsync(file);
                    hotel.ImageGallery.Add(url);
                }
            }

            await _hotelRepository.UpdateAsync(hotel);
            var dto = _mapper.Map<HotelDto>(hotel);

            return ResponseModel<HotelDto>.CreateSuccess(dto, "Hotel updated successfully");
        }


        public async Task<ResponseModel<bool>> DeleteHotelAsync(int id)
        {
            var hotel = await _hotelRepository.GetByIdAsync(id);
            if (hotel == null)
                return ResponseModel<bool>.CreateFailure("Hotel not found");

            await _hotelRepository.DeleteAsync(hotel);
            return ResponseModel<bool>.CreateSuccess(true, "Hotel deleted successfully");
        }

        public async Task<ResponseModel<IEnumerable<HotelDto>>> SearchHotelsByNameAsync(string name)
        {
            var hotels = await _hotelRepository.FindAsync(h => h.Name.Contains(name));

            var result = _mapper.Map<IEnumerable<HotelDto>>(hotels);

            if (!result.Any())
                return ResponseModel<IEnumerable<HotelDto>>.CreateSuccess(result, "No matching hotels found");

            return ResponseModel<IEnumerable<HotelDto>>.CreateSuccess(result, "Search result retrieved successfully");
        }

    }
}
