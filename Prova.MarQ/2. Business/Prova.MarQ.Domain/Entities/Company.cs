using System.ComponentModel.DataAnnotations;

namespace Prova.MarQ.Domain.Entities
{
    public class Company : Base
    {
        [Required]
        [MaxLength(100, ErrorMessage = "The name must not be more than 100 characters long.")]
        public string Name { get; set; }
        [Required]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "The document must be 11 characters long.")]
        public string Document { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public bool IsDeleted { get; set; }
    }
}
