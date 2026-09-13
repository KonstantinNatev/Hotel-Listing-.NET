using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HotelListing.Api.DTO.Hotel;
public class CreateHotelDto
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    
    [Required]
    [MaxLength(255)]
    public string Address { get; set; }

    [Range(0, 5)]
    public double Rating { get; set; }

    [Required]
    public int CountryId { get; set; }

}