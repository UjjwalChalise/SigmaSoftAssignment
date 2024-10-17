using System.ComponentModel.DataAnnotations;

namespace JobHub.Domain.Entities;

public class Candidate
{
    [Key]
    public int Id { get; set; }
    [Required]
    public required string FirstName { get; set; }
    [Required]
    [DataType(DataType.EmailAddress)]
    public required string Email { get; set; }
    [StringLength(maximumLength: 10)]
    public string? PhoneNumber { get; set; } = string.Empty;
    [Required]
    public required string LastName { get; set; }
    public string? TimeIntervalToCall { get; set; } = string.Empty;
    public string? LinkedInProfileUrl { get; set; } = string.Empty;
    public string? GitHubProfileUrl { get; set; } = string.Empty;
    [Required]
    public required string FreeTextComment { get; set; }
}
