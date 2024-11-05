

using Prova.MarQ.Domain.Entities;
using Prova.MarQ.Domain.Interfaces.Repositories;
using Prova.MarQ.Domain.Interfaces.Services;

namespace Prova.MarQ.Domain.Services
{
    public class CompanyService : ServiceBase<Company>, ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        public CompanyService(ICompanyRepository companyRepository) 
            : base(companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<Company> FindByDocument(string document)
        {
            return await _companyRepository.FindByDocument(document);
        }
    }
}
