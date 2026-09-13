using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HotelListing.Api.DTO.Hotel;
public record GetHotelsDto (
    int Id,
    string Name,
    string Address,
    double Rating,
    int CountryId
);

public record GetHotelsSlimDto (
    int Id,
    string Name,
    string Address,
    double Rating
);