using Prova.MarQ.Domain.Entities;
using Prova.MarQ.Domain.Interfaces.Repositories;
using Prova.MarQ.Domain.Interfaces.Services;
using System.Globalization;

namespace Prova.MarQ.Domain.Services
{
    public class TimeRecordService: ServiceBase<TimeRecord>, ITimeRecordService
    {
        private readonly ITimeRecordRepository _timerecordRepository;

        public TimeRecordService(ITimeRecordRepository timerecordRepository)
            : base(timerecordRepository)
        {
            _timerecordRepository = timerecordRepository;
        }

        public Task<IEnumerable<TimeRecordReport>> GetTimeRecordsReportAsync(DateTimeOffset startDate, DateTimeOffset endDate, string document = null)
        {
            return _timerecordRepository.GetTimeRecordsReportAsync(startDate, endDate, document);
        }

        public Task RegisterTimeRecordAsync(string pin)
        {
            return _timerecordRepository.RegisterTimeRecordAsync(pin);
        }
    }
}
