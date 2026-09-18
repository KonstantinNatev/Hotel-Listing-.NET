using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelListing.Api.Data;

public class ApiKey
{
    public int Id { get; set; }
    [MaxLength(256)]
    public string Key { get; set; } = string.Empty;

    [MaxLength(256)]
    public string AppName { get; set; } = string.Empty;

    public DateTimeOffset? ExpireAtUtc { get; set; }
    public DateTimeOffset? CreatedAtUtc { get; set; } = DateTimeOffset.UtcNow;

    [NotMapped]
    public bool IsActive => !ExpireAtUtc.HasValue || ExpireAtUtc.Value > DateTimeOffset.UtcNow;
}