using System.ComponentModel.DataAnnotations;

namespace Prova.MarQ.Domain.Entities
{
    public class Employee : Base
    {
        [Required]
        [MaxLength(100, ErrorMessage = "The name must not be more than 100 characters long.")]
        public string Name { get; set; }
        [Required]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "The document must be 11 characters long.")]
        public string Document { get; set; }
        [Required]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "PIN must contain 4 characters.")]
        public string PIN { get; set; }
        public Guid? CompanyId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
