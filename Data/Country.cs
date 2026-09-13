using System.ComponentModel.DataAnnotations;
using HotelListing.Api.Data;

public class Country
{
    public int CountryId { get; set; }
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    [Required]
    [MaxLength(10)]
    public string ShortName { get; set; }
    public List<Hotel>? Hotels { get; set; } = [];
}