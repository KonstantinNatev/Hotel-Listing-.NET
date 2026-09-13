using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HotelListing.Api.DTO.Hotel;
public class UpdateHotelDto : CreateHotelDto
{
    [Required]
    public int Id { get; set; }
}