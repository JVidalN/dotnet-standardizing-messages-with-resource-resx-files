using System.ComponentModel.DataAnnotations;

namespace someservice.Models
{
    public class InputModel
    {
        [Required(ErrorMessageResourceType = typeof(lib.ValidationMessages), ErrorMessageResourceName = "Required")]
        public string Name { get; set; }

        [EmailAddress(ErrorMessageResourceType = typeof(lib.ValidationMessages), ErrorMessageResourceName = "Email")]
        public string Email { get; set; }

        [StringLength(50, ErrorMessageResourceType = typeof(lib.ValidationMessages), ErrorMessageResourceName = "Length")]
        public string Address { get; set; }
    }
}
