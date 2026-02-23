using System.ComponentModel.DataAnnotations;

namespace SecureCientDataManagementFrontend.Models;

public class ClientDto
{
    [Required(ErrorMessage = "First Name is required")]
    [StringLength(50, ErrorMessage = "First Name cannot be longer than 50 characters")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last Name is required")]
    [StringLength(50, ErrorMessage = "Last Name cannot be longer than 50 characters")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Emirates ID is required")]
    [RegularExpression(@"^\d{3}-\d{4}-\d{7}-\d$",
        ErrorMessage = "Emirates ID must be in format XXXX-XXXX-XXXXXXX-X (e.g., 784-1234-5678901-2)")]
    public string EmiratesId { get; set; }
}