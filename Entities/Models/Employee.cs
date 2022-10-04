using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Employee
    {
        [Column("EmployeeId")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "FirstName is required.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is required.")]
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Position { get; set; }

        [ForeignKey(nameof(Project))] // Project sınıfına bağlı olarak oluşacak foreign key.
        public Guid? ProjectId { get; set; } // Foreign Key
        public Project Project { get; set; } // Navigation Property
    }
}
