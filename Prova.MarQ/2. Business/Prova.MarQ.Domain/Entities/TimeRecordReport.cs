
namespace Prova.MarQ.Domain.Entities
{
    public class TimeRecordReport
    {
        public DateTimeOffset Date { get; set; }
        public string EmployeeName { get; set; }
        public string Document { get; set; }
        public int PointsInDay { get; set; }
        public TimeSpan TotalWorked { get; set; }
        public TimeSpan TotalOvertime { get; set; }
        public string DayOfWeek { get; set; }
    }
}
