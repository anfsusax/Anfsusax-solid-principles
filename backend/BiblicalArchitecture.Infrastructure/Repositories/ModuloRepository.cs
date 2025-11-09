using System.Collections.Generic;
using System.Threading.Tasks;
using BiblicalArchitecture.Domain.Entidades;
using BiblicalArchitecture.Domain.Interfaces;
using BiblicalArchitecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BiblicalArchitecture.Infrastructure.Repositories
{
    public class ModuloRepository : IModuloRepository
    {
        private readonly ApplicationDbContext _context;

        public ModuloRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Modulo> ObterPorIdAsync(int id)
        {
            return await _context.Modulos
                .Include(m => m.Aulas)
                .Include(m => m.Exemplos)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Modulo>> ObterTodosAsync()
        {
            return await _context.Modulos
                .Include(m => m.Aulas)
                .Include(m => m.Exemplos)
                .OrderBy(m => m.Ordem)
                .ToListAsync();
        }

        public async Task AdicionarAsync(Modulo modulo)
        {
            await _context.Modulos.AddAsync(modulo);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Modulo modulo)
        {
            _context.Modulos.Update(modulo);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(int id)
        {
            var modulo = await ObterPorIdAsync(id);
            if (modulo != null)
            {
                _context.Modulos.Remove(modulo);
                await _context.SaveChangesAsync();
            }
        }
    }
}
