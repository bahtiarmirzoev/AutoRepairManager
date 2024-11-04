using System.ComponentModel.DataAnnotations;
using AutoRepairManagerApp.Core.Enums;

namespace AutoRepairManagerApp.Core.Models;

public class AutoRepair 
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    [Required]
    [StringLength(100)]
    public string? Name { get; set; }
    [Required]
    public (double Latitude, double Longitude) Location { get; set; } 
    [Required]
    [StringLength(100)]
    public string? Adress { get; set; }
    [Required]
    public IEnumerable<ServiceTypeEnum>? ServiceTypeEnums {get;set;}
    [Required]
    public Dictionary<string, (TimeSpan OpeningTime, TimeSpan ClosingTime)>? WorkingHours { get; set; }
    [Required]
    [Phone]
    [StringLength(15, MinimumLength = 7, ErrorMessage = "Phone number must be between 7 and 15 characters.")]
    [RegularExpression(@"^\+?[1-9]\d{1,14}$", ErrorMessage = "Invalid phone number format.")]
    public string? PhoneNumber { get; set; }
}