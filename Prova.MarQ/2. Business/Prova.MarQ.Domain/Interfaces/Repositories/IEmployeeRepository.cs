using Prova.MarQ.Domain.Entities;

namespace Prova.MarQ.Domain.Interfaces.Repositories
{
    public interface IEmployeeRepository : IRepositoryBase<Employee>
    {
        Task<Employee> FindByDocument(string document);
    }
}
