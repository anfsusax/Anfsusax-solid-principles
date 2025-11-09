using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiblicalArchitecture.Domain.Entidades.Solid;
using BiblicalArchitecture.Domain.Interfaces;

namespace BiblicalArchitecture.Domain.Servicos
{
    public class SolidService : ISolidService
    {
        private readonly List<PrincipioSolid> _principios;

        public SolidService()
        {
            _principios = new List<PrincipioSolid>
            {
                new SingleResponsability(),
                new OpenClosed(),
                new LiskovSubstitution(),
                new InterfaceSegregation(),
                new DependencyInversion()
            };
        }

        public Task<IEnumerable<PrincipioSolid>> ObterTodosPrincipiosAsync()
        {
            return Task.FromResult(_principios.AsEnumerable());
        }

        public Task<PrincipioSolid?> ObterPrincipioPorIdAsync(int id)
        {
            var principio = _principios.FirstOrDefault(p => 
                p.Id == id);
            
            return Task.FromResult<PrincipioSolid?>(principio);
        }

        public Task<PrincipioSolid?> ObterPrincipioPorSiglaAsync(string sigla)
        {
            var principio = _principios.FirstOrDefault(p => 
                p.Sigla.Equals(sigla, System.StringComparison.OrdinalIgnoreCase));
            
            return Task.FromResult<PrincipioSolid?>(principio);
        }
    }
}
