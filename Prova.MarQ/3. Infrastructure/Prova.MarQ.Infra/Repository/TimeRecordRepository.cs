using Microsoft.EntityFrameworkCore;
using Prova.MarQ.Domain.Entities;
using Prova.MarQ.Domain.Interfaces.Repositories;
using Prova.MarQ.Infra.Context;
using System.Globalization;

namespace Prova.MarQ.Infra.Repository
{

    public class TimeRecordRepository : RepositoryBase<TimeRecord>, ITimeRecordRepository
    {
        public TimeRecordRepository(ProvaMarQContext context) : base(context)
        {
        }
        public async Task RegisterTimeRecordAsync(string pin)
        {
            var employee = await _Db.Employees.FirstOrDefaultAsync(e => e.PIN == pin);
            DateTimeOffset today = DateTimeOffset.Now;

            if (employee == null) throw new ArgumentException("Employee not found");

            var timeRecord = new TimeRecord
            {
                EmployeeId = employee.Id,
                PIN = pin,
                breakStartTime = null,
                BreakCount = 0,
                TotalBreakTime = TimeSpan.Zero,
                CheckOut = today,                
            };

            await AddAsync(timeRecord);
        }

        public async Task<IEnumerable<TimeRecordReport>> GetTimeRecordsReportAsync(DateTimeOffset startDate, DateTimeOffset endDate, string? document = null)
        {

            var timeRecordsQuery = _Db.TimeRecords
                .Where(tr => !tr.IsDeleted);

            var employeeIdsWithDocument = new List<Guid>();
            if (!string.IsNullOrEmpty(document))
            {
                employeeIdsWithDocument = await _Db.Employees
                    .Where(e => !e.IsDeleted && e.Document == document)
                    .Select(e => e.Id)
                    .ToListAsync();

                timeRecordsQuery = timeRecordsQuery.Where(tr => employeeIdsWithDocument.Contains(tr.EmployeeId));
            }


            var timeRecords = await timeRecordsQuery.ToListAsync();

            timeRecords = timeRecords.Where(tr => tr.CreatedAt.Date >= startDate.Date && tr.CreatedAt.Date <= endDate.Date).ToList();

            var employees = await _Db.Employees
                .Where(e => !e.IsDeleted)
                .ToListAsync();

            var reportData = from tr in timeRecords
                             join e in employees on tr.EmployeeId equals e.Id
                             group new { tr, e } by new { tr.CreatedAt.Date, e.Name, e.Document, tr.BreakCount, tr.TotalWorked, tr.Overtime } into g
                             select new TimeRecordReport
                             {
                                 Date = g.Key.Date,
                                 EmployeeName = g.Key.Name,
                                 Document = g.Key.Document,
                                 PointsInDay = g.Key.BreakCount,
                                 TotalWorked = g.Key.TotalWorked,
                                 TotalOvertime = g.Key.Overtime,
                                 DayOfWeek = g.Key.Date.DayOfWeek.ToString()
                             };

            return reportData.ToList();
        }

    }
}
