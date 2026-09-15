using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using HotelListing.Api.DTO.Country;

namespace HotelListing.Api.DTO.Hotel;

public class GetHotelDto
{

    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public double Rating { get; set; } = 0;
    public string CountryName { get; set; } = string.Empty;
}
