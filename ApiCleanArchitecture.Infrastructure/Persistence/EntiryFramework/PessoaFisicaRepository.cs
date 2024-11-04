using ApiCleanArchitecture.Domain.Entities;
using ApiCleanArchitecture.Domain.IRepository;
using ApiCleanArchitecture.Infrastructure.Persistence.EntiryFramework.Context;

namespace ApiCleanArchitecture.Infrastructure.Persistence.EntiryFramework
{
    public class PessoaFisicaRepository : Repository<CirculacaoInterna>, IPessoaFisicaRepository
    {
        public PessoaFisicaRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {           
        }
    }
}
