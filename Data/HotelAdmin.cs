namespace HotelListing.Api.Data;

public class HotelAdmin
{
    public int Id { get; set; }
    public Hotel? Hote { get; set; }
    public int HotelId { get; set; }
    public ApplicationUser? User { get; set; }
    public required string UserId { get; set; } = string.Empty;

}