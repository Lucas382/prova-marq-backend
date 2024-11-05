using Prova.MarQ.Domain.Entities;

namespace Prova.MarQ.Domain.Interfaces.Services
{
    public interface IEmployeeService: IServiceBase<Employee>
    {
        Task<Employee> FindByDocument(string document);
    }
}
