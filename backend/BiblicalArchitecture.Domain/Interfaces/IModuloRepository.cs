using System.Collections.Generic;
using System.Threading.Tasks;
using BiblicalArchitecture.Domain.Entidades;

namespace BiblicalArchitecture.Domain.Interfaces
{
    public interface IModuloRepository
    {
        Task<Modulo> ObterPorIdAsync(int id);
        Task<IEnumerable<Modulo>> ObterTodosAsync();
        Task AdicionarAsync(Modulo modulo);
        Task AtualizarAsync(Modulo modulo);
        Task RemoverAsync(int id);
    }
}
