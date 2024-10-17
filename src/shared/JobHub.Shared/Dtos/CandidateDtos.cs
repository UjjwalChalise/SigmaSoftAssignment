

using System.ComponentModel.DataAnnotations;

namespace JobHub.Shared.Dtos;

public record CandidateDto
{
    [Required]
    [DataType(DataType.EmailAddress)]
    public required string Email { get; set; }

    [Required]
    public required string FirstName { get; set; }
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

public record CandidateListDto
{
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;
    public string LastName { get; set; }
    public string? TimeIntervalToCall { get; set; } = string.Empty;
    public string? LinkedInProfileUrl { get; set; } = string.Empty;
    public string? GitHubProfileUrl { get; set; } = string.Empty;
    public string FreeTextComment { get; set; }
}