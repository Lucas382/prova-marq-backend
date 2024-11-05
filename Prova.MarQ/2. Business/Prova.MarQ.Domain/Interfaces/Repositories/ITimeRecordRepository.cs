
using Prova.MarQ.Domain.Entities;

namespace Prova.MarQ.Domain.Interfaces.Repositories
{
    public interface ITimeRecordRepository: IRepositoryBase<TimeRecord>
    {
        Task RegisterTimeRecordAsync(string pin);
        Task<IEnumerable<TimeRecordReport>> GetTimeRecordsReportAsync(DateTimeOffset startDate, DateTimeOffset endDate, string? document = null);
    }
}
