using System.Collections.Generic;
using System.Threading.Tasks;
using BiblicalArchitecture.Domain.Entidades;

namespace BiblicalArchitecture.Domain.Interfaces
{
    public interface IModuloService
    {
        Task<Modulo> ObterModuloPorIdAsync(int id);
        Task<IEnumerable<Modulo>> ObterTodosModulosAsync();
        Task<Modulo> AdicionarModuloAsync(Modulo modulo);
    }
}
