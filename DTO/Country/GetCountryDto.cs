using HotelListing.Api.DTO.Hotel;

namespace HotelListing.Api.DTO.Country;

public class GetCountryDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ShortName { get; set; } = string.Empty;
    public List<GetHotelsSlimDto> Hotels { get; set; } = new();
}