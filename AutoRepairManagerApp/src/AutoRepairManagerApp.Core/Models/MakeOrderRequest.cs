using System.ComponentModel.DataAnnotations;

namespace AutoRepairManagerApp.Core.Models
{
    public class MakeOrderRequest
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Name can only contain letters and spaces.")]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^\+?[1-9]\d{1,14}$", ErrorMessage = "Phone number is not valid.")]
        public string Phone { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z0-9]{7,}$", ErrorMessage = "Technical Passport must contain at least 7 uppercase letters or digits.")]
        public string TechnicalPassport { get; set; }

        [Required]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Make can only contain letters and spaces.")]
        public string Make { get; set; }

        [Required]
        [RegularExpression(@"^[A-Za-z0-9\s]+$", ErrorMessage = "Model can only contain letters, digits, and spaces.")]
        public string Model { get; set; }

        [Required]
        [RegularExpression(@"^.{1000,}$", ErrorMessage = "Problem Description must be at least 1000 characters long.")]
        public string ProblemDescription { get; set; }
    }
}
