using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WebApiResource.Resources;

namespace WebApiResource.Models;

public class User
{
    [DisplayName("Name")]
    [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(ValidationMessages))]
    public required string Name { get; set; }

    [DisplayName("Email")]
    [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(ValidationMessages))]
    [EmailAddress(ErrorMessageResourceName = "Email", ErrorMessageResourceType = typeof(ValidationMessages))]
    public required string Email { get; set; }

    [DisplayName("Description")]
    [Range(minimum: 5, maximum: 10, ErrorMessageResourceName = "Length", ErrorMessageResourceType = typeof(ValidationMessages))]
    public string? Description { get; set; }
}
