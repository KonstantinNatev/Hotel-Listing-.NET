using HotelListing.api.Results;
using HotelListing.Api.DTO.Hotel;

namespace HotelListing.Api.Contracts;

public interface IHotelsService
{
    Task<Result<GetHotelDto>> CreateHotelAsync(CreateHotelDto hotelDto);
    Task<Result> DeleteHotelAsync(int id);
    Task<Result<GetHotelDto?>> GetHotelAsync(int id);
    Task<Result<IEnumerable<GetHotelsDto>>> GetHotelsAsync();
    Task<bool> HotelExistsAsync(int id);
    Task<bool> HotelNameExistsAsync(string name);
    Task<Result> UpdateHotelAsync(int id, UpdateHotelDto hotelDto);
}