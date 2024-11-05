using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prova.MarQ.Domain.Entities
{
    public class TimeRecord : Base
    {
        [Required]
        public Guid EmployeeId { get; set; }

        [Required]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "PIN must contain 4 characters.")]
        public string PIN { get; set; }

        public DateTimeOffset? breakStartTime;
        public int BreakCount { get; set; } = 0;
        public TimeSpan TotalBreakTime { get; set; } = TimeSpan.FromSeconds(0);
        public DateTimeOffset CheckOut { get; set; }
        public bool IsDeleted { get; set; }

        public string WeekDay
        {
            get => CreatedAt.Date.ToString("dddd");
        }

        [NotMapped]
        public TimeSpan TotalWorked
        {
            get
            {
                return (CheckOut - CreatedAt) - TotalBreakTime;
            }
        }

        [NotMapped]
        public TimeSpan Overtime
        {
            get => TotalWorked > TimeSpan.FromHours(8) ? TotalWorked - TimeSpan.FromHours(8) : TimeSpan.Zero;
        }

    }
}