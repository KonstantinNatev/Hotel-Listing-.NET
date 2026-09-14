using HotelListing.Api.DTO.Hotel;

namespace HotelListing.Api.Contracts;

public interface IHotelsService
{
    Task<IEnumerable<GetHotelsDto>> GetHotelsAsync();
    Task<GetHotelDto?> GetHotelAsync(int id);
    Task<GetHotelsDto> CreateHotelAsync(CreateHotelDto hotelDto);
    Task UpdateHotelAsync(int id, UpdateHotelDto hotelDto);
    Task DeleteHotelAsync(int id);
    Task<bool> HotelExistsAsync(int id);
    Task<bool> HotelNameExistsAsync(string name);
}