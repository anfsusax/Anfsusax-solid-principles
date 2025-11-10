using System.Collections.Generic;
using System.Threading.Tasks;
using BiblicalArchitecture.Domain.Entidades.Solid;
using BiblicalArchitecture.Domain.Interfaces;
using DomainSolidService = BiblicalArchitecture.Domain.Servicos.SolidService;

namespace BiblicalArchitecture.Application.Services
{
    public class SolidService : ISolidService
    {
        private readonly ISolidService _innerService;

        public SolidService()
        {
            _innerService = new DomainSolidService();
        }

        public Task<IEnumerable<PrincipioSolid>> ObterTodosPrincipiosAsync()
            => _innerService.ObterTodosPrincipiosAsync();

        public Task<PrincipioSolid?> ObterPrincipioPorIdAsync(int id)
            => _innerService.ObterPrincipioPorIdAsync(id);

        public Task<PrincipioSolid?> ObterPrincipioPorSiglaAsync(string sigla)
            => _innerService.ObterPrincipioPorSiglaAsync(sigla);
    }
}