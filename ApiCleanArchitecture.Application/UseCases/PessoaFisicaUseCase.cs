using ApiCleanArchitecture.Domain.Entities;
using ApiCleanArchitecture.Domain.IRepository;

namespace ApiCleanArchitecture.Application.UseCases
{
    public class PessoaFisicaUseCase
    {
        private readonly IPessoaFisicaRepository _pessoaFisicaRepository;
        public PessoaFisicaUseCase(IPessoaFisicaRepository pessoaFisicaRepository)
        {
            _pessoaFisicaRepository = pessoaFisicaRepository;
        }

        public async Task<IEnumerable<CirculacaoInterna>> GetAllCirculacaoInterna()
        {
            var result = await _pessoaFisicaRepository.GetAllAsync();

            return result;
        }
    }
}
