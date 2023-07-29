using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WebApiResource.Resources;

namespace WebApiResource.Models;

public class User
{
    [DisplayName("Name")]
    [Required]
    public required string Name { get; set; }

    [DisplayName("Email")]
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [DisplayName("Description")]
    [Required]
    [StringLength(maximumLength: 10, MinimumLength = 5)]
    public string? Description { get; set; }
}
