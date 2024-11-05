

using Microsoft.EntityFrameworkCore;
using Prova.MarQ.Domain.Entities;
using Prova.MarQ.Domain.Interfaces.Repositories;
using Prova.MarQ.Infra.Context;

namespace Prova.MarQ.Infra.Repository
{
    public class EmployeeRepository: RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ProvaMarQContext context) : base(context)
        {
        }

        public async Task<Employee> FindByDocument(string document)
        {
            return await _Db.Set<Employee>().FirstOrDefaultAsync(c => c.Document == document);
        }
    }
}
