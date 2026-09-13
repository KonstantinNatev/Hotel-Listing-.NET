using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using HotelListing.Api.DTO.Hotel;

namespace HotelListing.Api.DTO.Country;

public record GetCountryDto (
    int Id,
    string Name,
    string ShortName,
    List<GetHotelsSlimDto> Hotels
);