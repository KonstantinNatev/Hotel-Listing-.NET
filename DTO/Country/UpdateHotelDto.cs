using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HotelListing.Api.DTO.Country;
public class UpdateCountryDto : CreateCountryDto
{
    [Required]
    public int Id { get; set; }
}