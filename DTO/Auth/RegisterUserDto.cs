using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Antiforgery;

namespace HotelListing.Api.DTO.Auth;

public class RegisterUserDto : LoginUserDto
{
    [Required, MaxLength(20)]
    public string FirstName { get; set; } = string.Empty;
    [Required, MaxLength(20)]
    public string LastName { get; set; } = string.Empty;
    [Required, MaxLength(20)]
    public string UserName { get; set; } = string.Empty;
    public string Role { get; set; } = "User";
}

public class LoginUserDto
{
    [Required, EmailAddress]
    public string Email { get; set; } = string.Empty;
    [Required, MinLength(6)]
    public string Password { get; set; } = string.Empty;
}
