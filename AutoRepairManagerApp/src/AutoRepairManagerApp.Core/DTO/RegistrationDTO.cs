using System;
using System.ComponentModel.DataAnnotations;

namespace AutoRepairManagerApp.Core.DTO;
public class RegistrationDTO
{
    [Required(ErrorMessage = "Name is required.")]
    [StringLength(50, ErrorMessage = "Name length cannot be more than 50 characters.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Surname is required.")]
    [StringLength(50, ErrorMessage = "Surname length cannot be more than 50 characters.")]
    public string Surname { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    [StringLength(50, ErrorMessage = "Email length cannot be more than 50 characters.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    [StringLength(50, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters.")]
    public string Password { get; set; }
}
