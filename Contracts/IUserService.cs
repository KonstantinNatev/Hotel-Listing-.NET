using HotelListing.api.Results;
using HotelListing.Api.DTO.Auth;

namespace HotelListing.Api.Contracts;

public interface IUserSerivce
{
    string UserId { get; }
    Task<Result<string>> LoginAsync(LoginUserDto loginUserDto);
    Task<Result<RegisteredUserDto>> RegisterAsync(RegisterUserDto registerUserDto);
}