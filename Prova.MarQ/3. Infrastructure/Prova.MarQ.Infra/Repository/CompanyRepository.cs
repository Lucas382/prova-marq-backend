
using Microsoft.EntityFrameworkCore;
using Prova.MarQ.Domain.Entities;
using Prova.MarQ.Domain.Interfaces.Repositories;
using Prova.MarQ.Infra.Context;

namespace Prova.MarQ.Infra.Repository
{
    public class CompanyRepository: RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(ProvaMarQContext context) : base(context)
        {
        }

        public async Task<Company> FindByDocument(string document)
        {
            return await _Db.Set<Company>().FirstOrDefaultAsync(c => c.Document == document);
        }

    }
}
