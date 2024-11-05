using Prova.MarQ.Domain.Entities;

namespace Prova.MarQ.Domain.Interfaces.Repositories
{
    public interface ICompanyRepository : IRepositoryBase<Company>
    {
        Task<Company> FindByDocument(string document);
    }
}
