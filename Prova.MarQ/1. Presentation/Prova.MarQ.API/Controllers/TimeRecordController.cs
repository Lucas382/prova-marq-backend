using Microsoft.AspNetCore.Mvc;
using Prova.MarQ.Domain.Entities;
using Prova.MarQ.Domain.Interfaces.Services;
using System.ComponentModel.DataAnnotations;

namespace Prova.MarQ.API.Controllers
{
    public class TimeRecordController : ControllerBase
    {
        private readonly ITimeRecordService _timeRecordService;

        public TimeRecordController(ITimeRecordService timeRecordService)
        {
            _timeRecordService = timeRecordService;
        }


        [HttpPost("time_record/register")]
        public async Task<ActionResult> RegisterTimeRecord(string pin)
        {
            try
            {
                await _timeRecordService.RegisterTimeRecordAsync(pin);
                return Ok("Ponto registrado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("time_record/report")]
        public async Task<ActionResult<IEnumerable<TimeRecordReport>>> GetTimeRecordsReport(
            [Required] DateTime startDate,
            [Required] DateTime endDate,
            string? document = null)
        {
            if (startDate == default || endDate == default)
                return BadRequest("Datas de início e fim são obrigatórias.");

            var report = await _timeRecordService.GetTimeRecordsReportAsync(startDate, endDate, document);

            return Ok(report);
        }

        //[HttpPost("time_record/")]
        //public async Task<ActionResult> Create(TimeRecord timeRecord)
        //{
        //    await _timeRecordService.AddAsync(timeRecord);
        //    return CreatedAtAction(nameof(Create), new { id = timeRecord.Id }, timeRecord);

        //}

        //[HttpGet("time_record/{id}")]
        //public async Task<ActionResult<TimeRecord>> GetById(Guid id)
        //{
        //    var timeRecord = await _timeRecordService.GetByIdAsync(id);
        //    if (timeRecord == null)
        //    {
        //        return NotFound("Relatório não encontrado.");
        //    }
        //    return Ok(timeRecord);
        //}

        //[HttpGet("time_record/")]
        //public async Task<ActionResult<IEnumerable<TimeRecord>>> GetAll()
        //{
        //    var timeRecord = await _timeRecordService.GetAllAsync();
        //    return Ok(timeRecord);
        //}

        //[HttpPut("time_record/{id}")]
        //public async Task<ActionResult> Update(TimeRecord timeRecord)
        //{
        //    var existingTimeRecord = await _timeRecordService.GetByIdAsync(timeRecord.Id);
        //    if (existingTimeRecord == null)
        //    {
        //        return NotFound("Empresa não encontrada.");
        //    }

        //    await _timeRecordService.UpdateAsync(timeRecord);
        //    return Ok(200);
        //}

        //[HttpDelete("time_record/{id}")]
        //public async Task<ActionResult> SoftDelete(Guid id)
        //{
        //    var timeRecord = await _timeRecordService.GetByIdAsync(id);
        //    if (timeRecord == null)
        //    {
        //        return NotFound("Relatório não encontrado.");
        //    }

        //    await _timeRecordService.SoftDeleteAsync(timeRecord);
        //    return Ok(200);
        //}



    }
}
