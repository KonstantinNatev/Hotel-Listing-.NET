using HotelListing.api.Results;
using HotelListing.Api.DTO.Auth;

namespace HotelListing.Api.Contracts;

public interface IApiKeyValidatorService
{
    Task<bool> IsValidAsync(string apiKeym, CancellationToken cancellationToken = default);
}