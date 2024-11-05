
using Prova.MarQ.Domain.Entities;

namespace Prova.MarQ.Domain.Interfaces.Services
{
    public interface ITimeRecordService: IServiceBase<TimeRecord>
    {
        Task RegisterTimeRecordAsync(string pin);
        Task<IEnumerable<TimeRecordReport>> GetTimeRecordsReportAsync(DateTimeOffset startDate, DateTimeOffset endDate, string? document = null);

    }
}
