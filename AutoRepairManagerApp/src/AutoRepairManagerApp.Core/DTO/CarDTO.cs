using System;
using System.ComponentModel.DataAnnotations;

namespace AutoRepairManagerApp.Core.DTO;
public class CarDTO
{
    [Required(ErrorMessage = "Make is required.")]
    [StringLength(20, ErrorMessage = "Make length cannot be more than 20 characters.")]
    public string Make { get; set; }

    [Required(ErrorMessage = "Model is required.")]
    [StringLength(20, ErrorMessage = "Model length cannot be more than 20 characters.")]
    public string Model { get; set; }

    [Required(ErrorMessage = "Car plate is required.")]
    [RegularExpression(@"^\d{2}-\d{2}-\d{3}$", ErrorMessage = "Invalid car plate format. It should be in the format 00-AA-000.")]
    [StringLength(7, MinimumLength = 7, ErrorMessage = "Car plate must be 7 characters!")]
    public string CarPlate { get; set; }
}