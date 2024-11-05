
using Microsoft.AspNetCore.Mvc;
using Prova.MarQ.Domain.Entities;
using Prova.MarQ.Domain.Interfaces.Services;
using System.ComponentModel.DataAnnotations;

namespace Prova.MarQ.API.Controllers
{
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpPost("company/")]
        public async Task<ActionResult> Create(Company company)
        {

            var existingCompany = await _companyService.FindByDocument(company.Document);
            if (existingCompany != null)
            {
                return Conflict("O documento já está em uso.");
            }

            await _companyService.AddAsync(company);
            return CreatedAtAction(nameof(Create), new { id = company.Id }, company);

        }

        [HttpGet("company/{id}")]
        public async Task<ActionResult<Company>> GetById(Guid id)
        {
            var company = await _companyService.GetByIdAsync(id);
            if (company == null)
            {
                return NotFound("Empresa não encontrada.");
            }
            return Ok(company);
        }

        [HttpGet("company/")]
        public async Task<ActionResult<IEnumerable<Company>>> GetAll()
        {
            var companies = await _companyService.GetAllAsync();
            return Ok(companies);
        }

        [HttpPut("company/{id}")]
        public async Task<ActionResult> Update(Company company)
        {
            var existingCompany = await _companyService.GetByIdAsync(company.Id);
            if (existingCompany == null)
            {
                return NotFound("Empresa não encontrada.");
            }

            await _companyService.UpdateAsync(company);
            return Ok(200);
        }

        [HttpDelete("company/{id}")]
        public async Task<ActionResult> SoftDelete(Guid id)
        {
            var company = await _companyService.GetByIdAsync(id);
            if (company == null)
            {
                return NotFound("Empresa não encontrada.");
            }

            await _companyService.SoftDeleteAsync(company);
            return Ok(200);
        }



    }
}
