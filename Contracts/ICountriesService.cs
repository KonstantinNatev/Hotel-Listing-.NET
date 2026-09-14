using HotelListing.Api.DTO.Country;

namespace HotelListing.Api.Contracts;

public interface ICountriesService
{
    Task<IEnumerable<GetCountriesDto>> GetCountriesAsync();
    Task<GetCountryDto?> GetCountryAsync(int id);
    Task<GetCountryDto> CreateCountryAsync(CreateCountryDto countryDto);
    Task UpdateCountryAsync(int id, UpdateCountryDto countryDto);
    Task<bool> DeleteCountryAsync(int id);
    Task<bool> CountryExistsAsync(int id);
    Task<bool> CountryNameExistsAsync(string name);
}