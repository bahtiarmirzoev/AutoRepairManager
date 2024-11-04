using System.ComponentModel.DataAnnotations;

namespace AutoRepairManagerApp.Core.Models.Relations;

public class UserCars{
    [Key]
    public Guid UserId { get; set; }
    [Required]
    public IEnumerable<Guid>? CarId { get; set; }
}