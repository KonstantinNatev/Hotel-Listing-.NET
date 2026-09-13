using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HotelListing.Api.DTO.Country;
public class CreateCountryDto
{
    [Required]
    [MaxLength(50)]
    public required string Name { get; set; }

    [Required]
    [MaxLength(10)]
    public required string ShortName { get; set; }
}