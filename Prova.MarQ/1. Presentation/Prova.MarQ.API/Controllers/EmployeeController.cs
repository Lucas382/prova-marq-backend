
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prova.MarQ.Domain.Entities;
using Prova.MarQ.Domain.Interfaces.Services;

namespace Prova.MarQ.API.Controllers
{
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost("employee/")]
        public async Task<ActionResult> Create(Employee employee)
        {

            var existingEmployee = await _employeeService.FindByDocument(employee.Document);
            if (existingEmployee != null)
            {
                return Conflict("O documento já está em uso.");
            }

            await _employeeService.AddAsync(employee);
            return CreatedAtAction(nameof(Create), new { id = employee.Id }, employee);

        }

        [HttpGet("employee/{id}")]
        public async Task<ActionResult<Employee>> GetById(Guid id)
        {
            var employee = await _employeeService.GetByIdAsync(id);
            if (employee == null)
            {
                return NotFound("Funcionário não encontrado.");
            }
            return Ok(employee);
        }

        [HttpGet("employee/")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAll()
        {


            var employee = await _employeeService.GetAllAsync();
            return Ok(employee);
        }

        [HttpPut("employee/")]
        public async Task<ActionResult> Update(Employee employee)
        {
            var existingEmployee = await _employeeService.GetByIdAsync(employee.Id);
            if (existingEmployee == null)
            {
                return NotFound("Funcionário não encontrado.");
            }

            await _employeeService.UpdateAsync(employee);
            return Ok(200);
        }

        [HttpDelete("employee/{id}")]
        public async Task<ActionResult> SoftDelete(Guid id)
        {
            var employee = await _employeeService.GetByIdAsync(id);
            if (employee == null)
            {
                return NotFound("Funcionário não encontrada.");
            }

            await _employeeService.SoftDeleteAsync(employee);
            return Ok(200);
        }
    }
}
