using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HotelListing.Api.DTO.Country;
public record GetCountriesDto (
    int Id,
    string Name,
    string ShortName
);