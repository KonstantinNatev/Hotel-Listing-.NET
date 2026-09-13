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
public record GetHotelDto (
    int Id,
    string Name,
    string Address,
    double Rating,
    string CountryName
);
