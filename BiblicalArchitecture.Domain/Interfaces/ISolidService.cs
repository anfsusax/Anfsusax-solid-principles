using System.Collections.Generic;
using System.Threading.Tasks;
using BiblicalArchitecture.Domain.Entidades.Solid;

namespace BiblicalArchitecture.Domain.Interfaces
{
    public interface ISolidService
    {
        Task<IEnumerable<PrincipioSolid>> ObterTodosPrincipiosAsync();
        Task<PrincipioSolid?> ObterPrincipioPorIdAsync(int id);
        Task<PrincipioSolid?> ObterPrincipioPorSiglaAsync(string sigla);
    }
}
