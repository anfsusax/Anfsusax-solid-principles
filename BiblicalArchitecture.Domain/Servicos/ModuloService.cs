using System.Collections.Generic;
using System.Threading.Tasks;
using BiblicalArchitecture.Domain.Entidades;
using BiblicalArchitecture.Domain.Interfaces;

namespace BiblicalArchitecture.Domain.Servicos
{
    public class ModuloService : IModuloService
    {
        private readonly IModuloRepository _moduloRepository;

        public ModuloService(IModuloRepository moduloRepository)
        {
            _moduloRepository = moduloRepository;
        }

        public async Task<Modulo> ObterModuloPorIdAsync(int id)
        {
            return await _moduloRepository.ObterPorIdAsync(id);
        }

        public async Task<IEnumerable<Modulo>> ObterTodosModulosAsync()
        {
            return await _moduloRepository.ObterTodosAsync();
        }

        public async Task<Modulo> AdicionarModuloAsync(Modulo modulo)
        {
            await _moduloRepository.AdicionarAsync(modulo);
            return modulo;
        }
    }
}
