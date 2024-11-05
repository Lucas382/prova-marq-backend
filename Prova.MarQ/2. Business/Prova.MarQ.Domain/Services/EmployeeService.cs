

using Prova.MarQ.Domain.Entities;
using Prova.MarQ.Domain.Interfaces.Repositories;
using Prova.MarQ.Domain.Interfaces.Services;

namespace Prova.MarQ.Domain.Services
{
    public class EmployeeService: ServiceBase<Employee>, IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
            :base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Employee> FindByDocument(string document)
        {
            return await _employeeRepository.FindByDocument(document);
        }
    }
}
