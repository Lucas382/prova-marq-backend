using Prova.MarQ.Domain.Entities;

namespace Prova.MarQ.Domain.Interfaces.Services
{
    public interface ICompanyService: IServiceBase<Company>
    {
        Task<Company> FindByDocument(string document);
    }
}
